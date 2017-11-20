using System;
using System.Data;
using System.Data.SqlClient;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ORMSqlServer.cs
    /// Cette classe permet de gere la connexion à une base de données SQLServer
    /// Elle implémente l'interface ISQLConnection
    /// </summary>
    public class ORMSqlServer
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
    }
}
