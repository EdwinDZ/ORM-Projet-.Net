using System;
using System.Data;
using Npgsql;
using System.Reflection;
using ORMProjet.Exceptions;
using System.Collections.Generic;
using ORMProjet.Configuration;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ORMPostGreSQL.cd
    /// Cette classe permet de gérer la connexion à une base de données PostGreSQL
    /// Elle implémente l'interface ISQLConnection
    /// </summary>
    class ORMPostGreSQL : ISQLConnection
    {
        // Objet gérant la connexion avec la base de donnée
        NpgsqlConnection connection;

        /// <summary>
        /// Prépare la connexion avec la base de donnée sans l'ouvrir
        /// </summary>
        /// <param name="connectionString"> Chaine de connexion au serveur PostGreSQL</param>
        public ORMPostGreSQL(String connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        /// <summary>
        /// Ouvre la connexion sur la base de données
        /// </summary>
        /// <returns>
        /// True si la connexion s'est bien ouverte
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Connection()
        {
            try
            {
                // Si la connexion est "fermée" alors on "l'ouvre"
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return true;
            }
            catch (NpgsqlException ex)
            {
                switch (ex.ErrorCode)
                {
                    case 220:
                        throw new ORMExceptionsConnection("Connexion impossible, veuillez vérifier votre connectionString.", ex);
                        return false;
                    case 402:
                        throw new ORMExceptionsConnection("Impossible de se connecter à la base de données.", ex);
                        return false;
                    default:
                        return false;
                }
            }
        }


        /// <summary>
        /// Ferme la connexion à la base de données
        /// </summary>
        /// <returns>
        /// True si la connexion s'est bien fermé
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Disconnection()
        {
            try
            {
                // Fermeture de la connexion
                connection.Close();
                return true;
            }
            catch (NpgsqlException ex)
            {
                throw new ORMExceptionsDeconnection("Erreur lors de la déconnexion au serveur MySQL", ex);
                return false;
            }
        }

        /// <summary>
        /// Execute une requête PostGreSQL avec les paramètres
        /// </summary>
        /// <param name="req">Requête SQL paramétrable a exécuter</param>
        /// <param name="Param">Liste des différents paramètres traité pour éviter les injections SQL</param>
        /// <returns>
        /// True si la connexion s'est bien fermée
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Execute(String req, List<DboParameter> Param)
        {
            if (this.Connection() == true)
            {
                // Créer la connexion PostGreSQL
                NpgsqlCommand cmd = new NpgsqlCommand(req, connection);

                // Exécute la commande
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {
                    switch (ex.ErrorCode)
                    {
                        case 203:
                            throw new ORMExceptionsQuery("La requête a renvoyé plusieurs lignes mais les variables spécifiées ne sont pas des tableaux. La commande SELECT n'était pas unique.", ex);
                            return false;
                        case 208:
                            throw new ORMExceptionsQuery("La requête était vide. (Cela ne peut normalement pas se produire dans un programme Embedded SQL, ce qui peut indiquer une erreur interne.)", ex);
                            return false;
                        default:
                            return false;
                    }
                }

                // Ferme la connexion
                connection.Close();

                return true;
            }
            return false;
        }
        /// <summary>
        /// Récupère les résultats dans la base de données
        /// </summary>
        /// <typeparam name="T">Type d'objet à récupérer </typeparam>
        /// <param name="req">Requête a exécuter</param>
        /// <param name="Param">Liste des différents paramètres traité pour éviter les injections SQL</param>
        /// <returns></returns>
        public List<T> List<T>(String req, List<DboParameter> Param) where T : new()
        {
            // Liste d'objet générique à retourner
            List<T> list = new List<T>();

            // Ouvre une connexion
            if (this.Connection() == true)
            {
                // Créer une commande SQL
                NpgsqlCommand cmd = new NpgsqlCommand(req, connection);
                // Exécute la commande et récupère les données à travers PostGreSQLDataReader
                NpgsqlDataReader dataReader = cmd.ExecuteReader();

                // Index de la ligne courrante
                int currentRow = 0;
                // Lecteur ligne par ligne des résultats
                while (dataReader.Read())
                {
                    // Ajoute un objet générique à la liste de retour
                    list.Add(new T());

                    // Nombre de colonne associée à la ligne
                    int nbColumn = dataReader.FieldCount;

                    // pour chacune des colonnes du résultat
                    for (int i = 0; i < nbColumn; i++)
                    {
                        // Nom de la colonne "i"
                        String columnName = dataReader.GetName(i).ToLower();
                        // Nom de la colonne "i" avec la première lettre en majucule
                        String propertyName = FirstUpper(columnName);
                        // Valeur de la colonne
                        object columnValue = dataReader[columnName];

                        // Objet générique de la liste de retour associé au résultat parcouru [soit currentRow]
                        T obj = list[currentRow];
                        // Recupération du type de l'objet générique
                        Type type = obj.GetType();
                        // Récupération des informations de la propriété ayant le même nom que la column (à la majuscule Prêt)
                        PropertyInfo propInfo = type.GetProperty(propertyName);
                        // Si la propriété existe
                        if (propInfo != null)
                        {
                            // Mettre à jour la valeur de la propriété de l'objet générique
                            propInfo.SetValue(obj, columnValue);
                        }
                    }
                    // Incrémenter l'index de la ligne parcourue
                    currentRow++;
                }

                // Ferme le dataReader
                dataReader.Close();

                // Ferme la connexion
                connection.Close();

            }
            // Retourne la liste
            return list;
        }

        /// <summary>
        /// Permet de mettre la première lettre en majuscule
        /// </summary>
        /// <param name="str">Chaine de caractère à modifier</param>
        /// <returns>Retourne une chaine de caractère dont la première lettre est en majuscule</returns>
        private String FirstUpper(String str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}


