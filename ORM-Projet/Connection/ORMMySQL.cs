using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ORMProjet.Connection
{
    class ORMMySQL : ISQLConnection
    {

        private MySqlConnection connection;


        public ORMMySQL(String connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }


        public Boolean Connection()
        {
         try
            {
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


        public Boolean Disconnection()
        {
            try
            {
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
