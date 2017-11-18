using System;
using ORMProjet.Configuration;

namespace ORMProjet
{
    
    /// <summary>
    /// CLASS DE TEST DE CONNECTION
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
