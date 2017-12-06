using System;
namespace ORMProjet.Exceptions
{
    /// <summary>
    /// Class liée aux exceptions de connection de PostGreSQL.
    /// </summary>
    public class ORMExceptionsConnectionPostGreSql : Exception
    {

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsConnectionPostGreSql"/>.
        /// </summary>
        public ORMExceptionsConnectionPostGreSql()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsConnectionPostGreSql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsConnectionPostGreSql(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsConnectionPostGreSql"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsConnectionPostGreSql(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
