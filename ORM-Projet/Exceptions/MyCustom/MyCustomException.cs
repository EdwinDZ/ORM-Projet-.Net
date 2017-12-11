using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de déconnection de MySql.
    /// </summary>
    public class MyCustomException : Exception
    {

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.MyCustomException"/>.
        /// </summary>
        public MyCustomException()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.MyCustomException"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public MyCustomException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.MyCustomException"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public MyCustomException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
