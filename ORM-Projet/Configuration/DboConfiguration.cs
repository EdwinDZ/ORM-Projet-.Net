using System;
namespace ORMProjet.Configuration
{
    /// <summary>
    /// Class : DboConfiguration.cd
    /// Classe abstraite permettant de configurer la chaine de connexion et le type de base de donnée
    /// </summary>
    public abstract class DboConfiguration
    {
        /// <summary>
        /// Enumération des différents type de SGBD
        /// </summary>
        public enum TypeSGBD
        {
            MySQL,
            SQLSERVER,
            POSTGRESQL
        }

        /// <summary>
        /// Récupère le type de base de données utilisé
        /// </summary>
        /// <returns>Retourne le type de base de données</returns>
        abstract public TypeSGBD GetDbType();

        /// <summary>
        /// Récupère la chaine de connexion
        /// </summary>
        /// <returns>Retourne la chaine de connexion</returns>
        abstract public string GetConnectionString();
    }
}
