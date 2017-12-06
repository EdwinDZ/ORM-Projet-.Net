using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de déconnection de SqlServer.
    /// </summary>
    public class ORMExceptionsDeconnectionSqlServer : Exception
    {

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionSqlServer"/>.
        /// </summary>
        public ORMExceptionsDeconnectionSqlServer()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionSqlServer"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsDeconnectionSqlServer(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionSqlServer"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsDeconnectionSqlServer(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
