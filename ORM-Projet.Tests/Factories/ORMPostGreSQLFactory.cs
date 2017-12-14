using ORMProjet.Connection;
// <copyright file="ORMPostGreSQLFactory.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;

namespace ORMProjet.Connection
{
    /// <summary>A factory for ORMProjet.Connection.ORMPostGreSQL instances</summary>
    public static partial class ORMPostGreSQLFactory
    {
        /// <summary>A factory for ORMProjet.Connection.ORMPostGreSQL instances</summary>
        [PexFactoryMethod(typeof(ORMPostGreSQL))]
        public static ORMPostGreSQL Create(string connectionString_s)
        {
            ORMPostGreSQL oRMPostGreSQL = new ORMPostGreSQL(connectionString_s);
            return oRMPostGreSQL;

            // TODO: Edit factory method of ORMPostGreSQL
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
