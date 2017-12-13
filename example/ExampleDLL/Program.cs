using System;
using System.Collections.Generic;
using ORMProjet.Configuration;
using ORMProjet.Mapping;

namespace ORMProjet 
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instanciation de la configuration
            Config conf = new Config();
            // Création du mapper via 
            DboMapper mapper = new DboMapper(conf);

            // Exécution de la requête List()
            List<Author> lst = DboMapper.List<Author>(@"SELECT * FROM author", new List<DboParameter>());

            // Exécution de la requête List()
            List<DboParameter> param = new List<DboParameter>();
            param.Add(new DboParameter("@name", "Victor Hugault"));
            DboMapper.Execute(@"INSERT INTO author (name) VALUES (@name);", param);
        }
    }

    /// <summary>
    /// Class Author
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Created { get; set; }
    }

    /// <summary>
    /// Class Config qui permet de créer la configuration de connexion à la base de donnée
    /// </summary>
    public class Config : DboConfiguration
    {
        
        public override string GetConnectionString()
        {
            // Attribution de la connString
            return "Server=localhost;Database=mydb;Uid=root;";
        }

        public override TypeSGBD GetDbType()
        {
            // Retourne le type de DB auquel on se connecte
            return TypeSGBD.MySQL;
        }
    }
}
