using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de l'exécution des query.
    /// </summary>
    public class ORMExceptionsQuery : Exception
    {

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsQuery"/>.
        /// </summary>
        public ORMExceptionsQuery()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsQuery"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsQuery(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsQuery"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsQuery(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
