using System;
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
    }
}
