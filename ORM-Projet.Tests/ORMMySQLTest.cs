// <copyright file="ORMMySQLTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Connection;

namespace ORMProjet.Connection.Tests
{
    [TestClass]
    [PexClass(typeof(ORMMySQL))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ORMMySQLTest
    {

        [PexMethod]
        public ORMMySQL Constructor(string connectionString)
        {
            ORMMySQL target = new ORMMySQL(connectionString);
            return target;
            // TODO: ajouter des assertions à méthode ORMMySQLTest.Constructor(String)
        }
    }
}
