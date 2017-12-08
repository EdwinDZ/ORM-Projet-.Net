using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using ORMProjet.Exceptions;
using System.Collections.Generic;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ORMMySQL.cs
    /// Cette classe permet de gérer la connexion à une base de données MySQL
    /// Elle implémente l'interface ISQLConnection
    /// </summary>
    class ORMMySQL : ISQLConnection
    {
        // Objet gérant la connexion avec la base de données
        private MySqlConnection connection;

        /// <summary>
        /// Prépare la connexion avec la base de données sans l'ouvrir
        /// </summary>
        /// <param name="connectionString"> Chaine de connexion au serveur MySQL</param>
        public ORMMySQL(String connectionString)
        {
            connection = new MySqlConnection(connectionString);
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
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0 : 
                        throw new ORMExceptionsConnectionMySql("Connexion au serveur MySQL impossible.", ex);
                        return false;
                    case 1045 : 
                        throw new ORMExceptionsConnectionMySql("Combinaison username / password incorrecte.", ex);
                        return false;
                    case 2049 :
                        throw new ORMExceptionsConnectionMySql("Connexion à l'aide de l'ancien protocole d'authentification refusé (option client 'secure_auth' activée)", ex);
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
        /// True si la connexion s'est bien fermée
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
            catch (MySqlException ex)
            {
                throw new ORMExceptionsDeconnectionMySql("Erreur lors de la déconnexion au serveur MySQL", ex);
                return false;
            }
        }

        /// <summary>
        /// Exécute une requête MySQL avec les paramètres
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
                // Créer la connexion MYSQL
                MySqlCommand cmd = new MySqlCommand(req, connection);

                // Exécute la commande
                // TODO Gère les erreurs
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new ORMExceptionsQueryMySql("Connection au serveur MySQL perdue pendant la requête", ex);
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
        /// <param name="req">Requête à exécuter</param>
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
                MySqlCommand cmd = new MySqlCommand(req, connection);
                // Exécute la commande et récupère les données à travers MySqlDataReader
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Index de la ligne courrante
                int currentRow = 0;
                // Lecteur ligne par ligne des résultats
                while (dataReader.Read())
                {
                    // Ajoute un objet générique à la liste de retour
                    list.Add(new T());

                    // Nombre de colonne associé à la ligne
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
                        // Récupération du type de l'objet générique
                        Type type = obj.GetType();
                        // Récupération des informations de la propriété ayant le même nom que la colonne (a la majuscule Prêt)
                        PropertyInfo propInfo = type.GetProperty(propertyName);
                        // Si la propriété existe
                        if (propInfo != null)
                        {
                            // Mettre à jour la valeur de la propriété de l'objet générique
                            propInfo.SetValue(obj, columnValue);
                        }
                    }
                    // Incrémente l'index de la ligne parcourue
                    currentRow++;
                }

                // Ferme le dataReader
                dataReader.Close();

                // Ferme la connexion
                connection.Close();

            }
            // Retourner la list
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


