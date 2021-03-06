﻿using System;
namespace ORMProjet.Exceptions
{

    /// <summary>
    /// Class liée aux exceptions de déconnection de MySql.
    /// </summary>
    public class ORMExceptionsDeconnection : Exception
    {
        
        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnection"/>.
        /// </summary>
        public ORMExceptionsDeconnection()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnection"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        public ORMExceptionsDeconnection(string message) : base(message)
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="T:ORMProjet.Exceptions.ORMExceptionsDeconnection"/>.
        /// </summary>
        /// <param name="message">Message d'erreur à retourner.</param>
        /// <param name="inner">Association de l'exception, de base, complète.</param>
        public ORMExceptionsDeconnection(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
