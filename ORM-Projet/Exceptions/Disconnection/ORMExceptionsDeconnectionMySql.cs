using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de déconnection de MySql.
    /// </summary>
    public class ORMExceptionsDeconnectionMySql : Exception
    {
        
        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionMySql"/>.
        /// </summary>
        public ORMExceptionsDeconnectionMySql()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionMySql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsDeconnectionMySql(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionMySql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsDeconnectionMySql(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
