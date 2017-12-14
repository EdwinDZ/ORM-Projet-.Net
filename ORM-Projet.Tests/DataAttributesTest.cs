using System.Collections.Generic;
// <copyright file="DataAttributesTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Mapping;

namespace ORMProjet.Mapping.Tests
{
    [TestClass]
    [PexClass(typeof(DataAttributes))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DataAttributesTest
    {

        [PexMethod]
        public List<string> GetDataNames(Type type, string propertyName)
        {
            List<string> result = DataAttributes.GetDataNames(type, propertyName);
            return result;
            // TODO: ajouter des assertions à méthode DataAttributesTest.GetDataNames(Type, String)
        }
    }
}
