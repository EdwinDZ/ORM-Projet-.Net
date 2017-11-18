using System;
using System.Data;
using Npgsql;

namespace ORMProjet.Connection
{
    public class ORMPostGreSQL : ISQLConnection
    {

        NpgsqlConnection connection;


        public ORMPostGreSQL(String connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
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
