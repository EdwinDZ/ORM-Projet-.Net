using System;
using System.Data;
using System.Data.SqlClient;

namespace ORMProjet.Connection
{
    public class ORMSqlServer
    {

        SqlConnection connection;


        public ORMSqlServer(String connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public Boolean Connection()
        {
            try
            {
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
