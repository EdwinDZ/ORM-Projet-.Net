using ORMProjet.Configuration;
using System;
using System.Collections.Generic;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ISQLConnection.cd
    /// Interface permettant de configurer la chaine de connexion et le type de base de donnée
    /// </summary>
    public interface ISQLConnection
    {
        /// <summary>
        /// Ouvre une connextion
        /// </summary>
        /// <returns></returns>
        Boolean Connection();

        /// <summary>
        /// Ferme la connexion
        /// </summary>
        /// <returns></returns>
        Boolean Disconnection();

        /// <summary>
        /// Exécute la requête SQL avec les paramètre associés
        /// </summary>
        /// <param name="request">Requête paramatré à exécuter</param>
        /// <param name="parameters">Liste de paramètres à traiter contre les injections SQL</param>
        /// <returns></returns>
        Boolean Execute(String request, List<DboParameter> parameters);

        /// <summary>
        /// Retourne les résultat d'un SELECT en Base de donnée
        /// </summary>
        /// <typeparam name="T">Type de l'objet voulu</typeparam>
        /// <param name="request">Requête paramatré à éxecuter</param>
        /// <param name="parameters">Liste de paramètres à traiter contre les injections SQL</param>
        /// <returns></returns>
        List<T> List<T>(String request, List<DboParameter> parameters) where T : new();
    }
}
