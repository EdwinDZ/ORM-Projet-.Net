// <copyright file="ORMSqlServerTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Connection;

namespace ORMProjet.Connection.Tests
{
    [TestClass]
    [PexClass(typeof(ORMSqlServer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ORMSqlServerTest
    {

        [PexMethod]
        public ORMSqlServer Constructor(string connectionString)
        {
            ORMSqlServer target = new ORMSqlServer(connectionString);
            return target;
            // TODO: ajouter des assertions à méthode ORMSqlServerTest.Constructor(String)
        }
    }
}
