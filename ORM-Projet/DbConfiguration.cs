using System;
using ORMProjet.Configuration;

namespace ORMProjet
{
    /// <summary>
    /// Class : DbConfiguration.cs
    /// Cette classe permet de tester le fonctionnement à une base de données de type MySQL
    /// Elle implémente la class DboConfiguration
    /// </summary>
    class DbConfiguration : DboConfiguration
    {
        public DbConfiguration()
        {
        }

        public override string GetConnectionString()
        {
            return "Server=localhost;Port=8889;Database=orm;Uid=root;Pwd=root;";
        }

        public override TypeSGBD GetDbType()
        {
            return TypeSGBD.MySQL;
        }
    }
}
