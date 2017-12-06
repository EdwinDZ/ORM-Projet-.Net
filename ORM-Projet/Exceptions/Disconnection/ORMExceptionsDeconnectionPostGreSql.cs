using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de déconnection de PostGreSQL.
    /// </summary>
    public class ORMExceptionsDeconnectionPostGreSql : Exception
    {

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionPostGreSql"/>.
        /// </summary>
        public ORMExceptionsDeconnectionPostGreSql()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionPostGreSql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsDeconnectionPostGreSql(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnectionPostGreSql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsDeconnectionPostGreSql(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
