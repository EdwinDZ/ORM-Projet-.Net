using System;
namespace ORMProjet.Configuration
{
    abstract class DboConfiguration
    {
        public enum TypeSGBD
        {
            MySQL,
            SQLSERVER,
            POSTGRESQL
        }

        abstract public TypeSGBD GetDbType();

        abstract public string GetConnectionString();
    }
}
