﻿using ORMProjet.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ORMProjet.Configuration;

namespace ORMProjet.Connection
{
    /// <summary>
    /// Class : ORMSqlServer.cs
    /// Cette classe permet de gérer la connexion à une base de données SQLServer
    /// Elle implémente l'interface ISQLConnection
    /// </summary>
    class ORMSqlServer : ISQLConnection
    {
        // Objet gérant la connexion avec la base de données
        SqlConnection connection;

        /// <summary>
        /// Prépare la connexion avec la base de données sans l'ouvrir
        /// </summary>
        /// <param name="connectionString"> Chaine de connexion au serveur SQLServer</param>
        public ORMSqlServer(String connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Ouvre la connexion sur la base de données
        /// </summary>
        /// <returns>
        /// True si la connexion s'est bien ouverte
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Connection()
        {
            try
            {
                // Si la connexion est "fermée" alors on "l'ouvre"
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 4060:
                        throw new ORMExceptionsConnection("Impossible d'ouvrir la base de donnée demandée par le login. La connexion a échoué.", ex);
                        return false;
                    case 40613:
                        throw new ORMExceptionsConnection("La base de données sur le serveur n'est pas disponible actuellement. Veuillez réessayer la connexion plus tard. Si le problème persiste, contactez le service client.", ex);
                        return false;
                    case 40852:
                        throw new ORMExceptionsConnection(" Impossible d'ouvrir la base de données sur le serveur demandé par le login. L'accès à la base de données est uniquement autorisé à l'aide d'une chaîne de connexion sécurisée.", ex);
                        return false;
                    default:
                        return false;
                }
            }
        }

        /// <summary>
        /// Ferme la connexion a la base de données
        /// </summary>
        /// <returns>
        /// True si la connexion s'est bien fermée
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Disconnection()
        {
            try
            {
                // Fermeture de la connexion
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                throw new ORMExceptionsDeconnection("Erreur lors de la déconnexion au serveur MySQL", ex);
                return false;
            }
        }

        /// <summary>
        /// Exécute une requête SQLServer avec les paramètres
        /// </summary>
        /// <param name="req">Requête SQL paramétrable à exécuter</param>
        /// <param name="Param">Liste des différents paramètres traité pour éviter les injections SQL</param>
        /// <returns>
        /// True si la connexion s'est bien fermée
        /// False si une erreur est survenue
        /// </returns>
        public Boolean Execute(String req, List<DboParameter> Param)
        {
            if (this.Connection() == true)
            {
                // Créer la connexion SQLServer
                SqlCommand cmd = new SqlCommand(req, connection);

                // Exécute la commande
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 49918:
                            throw new ORMExceptionsQuery("Impossible de traiter la requête. Ressources insuffisantes pour traiter la demande. Le service est actuellement occupé. Relancez la requête ultérieurement.", ex);
                            return false;
                        case 49919:
                            throw new ORMExceptionsQuery("Le service est occupé à traiter plusieurs demandes de création ou de mise à jour pour votre abonnement ou le serveur.Patientez jusqu’à ce que les demandes de création ou de mise à jour soient terminées ou supprimez l’une de vos requêtes en cours et réessayez votre requête ultérieurement.", ex);
                            return false;
                        case 49920:
                            throw new ORMExceptionsQuery("Le serveur est trop occupé pour prendre en charge les requêtes supérieures à %d pour cette base de données", ex);
                            return false;
                        case 40551:
                            throw new ORMExceptionsQuery("La session a été arrêtée en raison de l’utilisation excessive de TEMPDB . Essayez de modifier votre requête pour réduire l’espace utilisé par la table temporaire.", ex);
                            return false;
                        case 40553:
                            throw new ORMExceptionsQuery("La session a été arrêtée en raison d’une utilisation excessive de la mémoire. Essayez de modifier votre requête pour traiter moins de lignes.", ex);
                            return false;
                        default:
                            return false;
                    }
                }

                // Ferme la connexion
                connection.Close();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Récupère les résultats dans la base de données 
        /// </summary>
        /// <typeparam name="T">Type d'objet à récupérer </typeparam>
        /// <param name="req">Requête à exécuter</param>
        /// <param name="Param">Liste des différents paramètres traités pour éviter les injections SQL</param>
        /// <returns></returns>
        public List<T> List<T>(String req, List<DboParameter> Param) where T : new()
        {
            // Liste d'objet générique à retourner
            List<T> list = new List<T>();

            // Ouvre une connexion
            if (this.Connection() == true)
            {
                // Créer une commande SQL
                SqlCommand cmd = new SqlCommand(req, connection);
                // Exécute la commande et récupère les données à travers SQLServerDataReader
                SqlDataReader dataReader = cmd.ExecuteReader();

                // Index de la ligne courrante
                int currentRow = 0;
                // Lecteur ligne par ligne des résultats
                while (dataReader.Read())
                {
                    // Ajoute un objet générique à la liste de retour
                    list.Add(new T());

                    // Nombre de colonne associée à la ligne
                    int nbColumn = dataReader.FieldCount;

                    // pour chacune des colonnes du résultat
                    for (int i = 0; i < nbColumn; i++)
                    {
                        // Nom de la colonne "i"
                        String columnName = dataReader.GetName(i).ToLower();
                        // Nom de la colonne "i" avec la première lettre en majucule
                        String propertyName = FirstUpper(columnName);
                        // Valeur de la colonne
                        object columnValue = dataReader[columnName];

                        // Objet générique de la liste de retour associée au résultat parcouru [soit currentRow]
                        T obj = list[currentRow];
                        // Recupération du type de l'objet générique
                        Type type = obj.GetType();
                        // Récupération des informations de la propriété ayant le même nom que la column (a la majuscule Pret)
                        PropertyInfo propInfo = type.GetProperty(propertyName);
                        // Si la propriété existe
                        if (propInfo != null)
                        {
                            // Mettre à jour la valeur de la propriété de l'objet générique
                            propInfo.SetValue(obj, columnValue);
                        }
                    }
                    // Incrémente l'index de la ligne parcourue
                    currentRow++;
                }

                // Ferme le dataReader
                dataReader.Close();

                // Ferme la connexion
                this.Disconnection();

            }
            
            // Retourné la liste
            return list;
        }

        /// <summary>
        /// Permet de mettre la première lettre en majuscule
        /// </summary>
        /// <param name="str">Chaine de caractère à modifier</param>
        /// <returns>Retourne une chaine de caractère dont la première lettre est en majuscule</returns>
        private String FirstUpper(String str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}


