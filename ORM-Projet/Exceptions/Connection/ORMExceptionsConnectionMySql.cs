using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de connection de MySql.
    /// </summary>
    public class ORMExceptionsConnectionMySql : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsConnectionMySql"/>.
        /// </summary>
        public ORMExceptionsConnectionMySql()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsConnectionMySql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsConnectionMySql(string message): base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsConnectionMySql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsConnectionMySql(string message, Exception inner): base(message, inner)
        {
        }
    }
}
