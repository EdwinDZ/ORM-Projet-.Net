﻿using ORMProjet.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ORMSqlServer.cs
    /// Cette classe permet de gere la connexion à une base de données SQLServer
    /// Elle implémente l'interface ISQLConnection
    /// </summary>
    class ORMSqlServer
    {
        // Objet gérant la connexion avec la base de donnée
        SqlConnection connection;

        /// <summary>
        /// Prépare la connexion avec la base de donnée sans l'ouvrir
        /// </summary>
        /// <param name="connectionString"> Chaine de connextion au serveur SQLServer</param>
        public ORMSqlServer(String connectionString)
        {
            connection = new SqlConnection(connectionString);
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
                // Si la connection est "fermée" alors on "l'ouvre"
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Ferme la connexion a la base de données
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
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Execute une requete SQLServer avec les paramètres
        /// </summary>
        /// <param name="req">Requête SQL paramétrable a executer</param>
        /// <param name="Param">Liste des différents paramètres traité pour éviter les injection SQL</param>
        /// <returns>
        /// True si la connexion c'est bien fermé
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Execute(String req, List<DboParameter> Param)
        {
            if (this.Connection() == true)
            {
                // Créer la connextion SQLServer
                SqlCommand cmd = new SqlCommand(req, connection);

                // Execute la commande
                // TODO Gérer les erreurs
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("message", ex);
                }

                // Ferme la connexion
                connection.Close();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Récupère les résultats dans la base de donnée 
        /// </summary>
        /// <typeparam name="T">Type d'objet a récupérer </typeparam>
        /// <param name="req">Requête a exeucter</param>
        /// <param name="Param">Liste des différents paramètres traité pour éviter les injection SQL</param>
        /// <returns></returns>
        public List<T> List<T>(String req, List<DboParameter> Param) where T : new()
        {
            // Liste d'objet générique à retourner
            List<T> list = new List<T>();

            // Ouvre une connexion
            if (this.Connection() == true)
            {
                // Créer une commande SQL
                SqlCommand cmd = new SqlCommand(req, connection);
                // Execute la commande et récupère les donnée à travers SQLServerDataReader
                SqlDataReader dataReader = cmd.ExecuteReader();

                // Index de la ligne courrante
                int currentRow = 0;
                // Lecteur ligne par ligne des résultats
                while (dataReader.Read())
                {
                    // Ajoute un objet générique a la list de retour
                    list.Add(new T());

                    // Nombre de colonne associé à la ligne
                    int nbColumn = dataReader.FieldCount;

                    // pour chacune des column du résultat
                    for (int i = 0; i < nbColumn; i++)
                    {
                        // Nom de la column "i"
                        String columnName = dataReader.GetName(i).ToLower();
                        // Nom de la column "i" avec la premiere lettre en majucule
                        String propertyName = FirstUpper(columnName);
                        // Valeur de la column.
                        object columnValue = dataReader[columnName];

                        // Objet générique de la liste de retour associer au resultat parcourur [soit currentRow]
                        T obj = list[currentRow];
                        // Recupération du type de l'objet générique
                        Type type = obj.GetType();
                        // Récupération des information de la propriété ayant le même nom que la column (a la majuscule Pret)
                        PropertyInfo propInfo = type.GetProperty(propertyName);
                        // Si la propriété existe
                        if (propInfo != null)
                        {
                            // Mettre a jour la valeur de la propriété de l'objet générique
                            propInfo.SetValue(obj, columnValue);
                        }
                    }
                    // Incrémenté l'index de la ligne parcourue
                    currentRow++;
                }

                // Fermer le dataReader
                dataReader.Close();

                // Fermer la connexion
                this.Disconnection();

            }
            
            // Retourner la list
            return list;
        }

        /// <summary>
        /// Permet de mettre la premier lettre en majuscule
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

