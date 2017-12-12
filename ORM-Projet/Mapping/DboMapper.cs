using System;
using System.Collections.Generic;
using ORMProjet.Configuration;
using ORMProjet.Connection;

namespace ORMProjet.Mapping
{
    /// <summary>
    /// Cette classe permet executer des requête
    /// selon l'objet passer en paramètre
    /// </summary>
    class DboMapper
    {
        // Gestionnaire de la connexion au server SQL
        static private ISQLConnection conn;

        /// <summary>
        /// Constructeur permetant la configuration de la connexion a la base de donnée
        /// </summary>
        /// <param name="cls">
        /// Objet de configuration de connexion de la base de donnée
        /// créer par l'utilisateur
        /// </param>
        public DboMapper(DboConfiguration cls)
        {
            // Vérification du SGBD
            switch (cls.GetDbType())
            {
                case DboConfiguration.TypeSGBD.MySQL:
                    // Création d'une connexion à une base de donnée MYSQL
                    conn = new ORMMySQL(cls.GetConnectionString());
                    conn.Connection();
                    break;
                case DboConfiguration.TypeSGBD.POSTGRESQL:
                    // Création d'une connexion à une base de donnée MYSQL
                    conn = new ORMPostGreSQL(cls.GetConnectionString());
                    conn.Connection();
                    break;
                case DboConfiguration.TypeSGBD.SQLSERVER:
                    // Création d'une connexion àune base de donnée SqlServer
                    conn = new ORMSqlServer(cls.GetConnectionString());
                    break;
            }
        }

        /// <summary>
        /// Execution d'une requete
        /// </summary>
        /// <param name="request">Requete paramétrée à executer</param>
        /// <param name="parameters">Paramètre de la requete à executer</param>
        /// <returns></returns>
        public static Boolean Execute(String request, List<DboParameter> parameters)
        {
            request = SetParams(request, parameters);
            return conn.Execute(request, parameters);
        }

        /// <summary>
        /// Recupère les resultat SQL pour les associés à une liste d'objet.
        /// </summary>
        /// <typeparam name="T">Type de l'objet voulu</typeparam>
        /// <param name="request">Requete paramétrée à executer</param>
        /// <param name="parameters">Paramètre de la requete à executer</param>
        /// <returns></returns>
        public static List<T> List<T>(String request, List<DboParameter> parameters) where T : new()
        {
            return conn.List<T>(request, parameters);
        }

        /// <summary>
        /// Associe les valeurs des paramètre dans la requete en les echappant
        /// </summary>
        /// <param name="request"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        // TODO Echapement des paramètres
        private static String SetParams(String request, List<DboParameter> parameters)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                request = request.Replace(parameters[i].Key, "'" + parameters[i].Value + "'");
            }
            return request;
        }
    }
}
