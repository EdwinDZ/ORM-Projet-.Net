﻿using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ORMMySQL.cs
    /// Cette classe permet de gere la connexion à une base de données MySQL
    /// Elle implémente l'interface ISQLConnection
    /// </summary>
    class ORMMySQL : ISQLConnection
    {
        // Objet gérant la connexion avec la base de donnée
        private MySqlConnection connection;

        /// <summary>
        /// Prépare la connexion avec la base de donnée sans l'ouvrir
        /// </summary>
        /// <param name="connectionString"> Chaine de connextion au serveur MySQL</param>
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
                // Si la connection est "fermée" alors on "l'ouvre"
                if(connection.State == ConnectionState.Closed)
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
    }
}
