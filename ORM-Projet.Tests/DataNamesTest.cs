using System.Collections.Generic;
// <copyright file="DataNamesTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Mapping;

namespace ORMProjet.Mapping.Tests
{
    [TestClass]
    [PexClass(typeof(DataNames))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DataNamesTest
    {

        [PexMethod]
        public void ValueNamesSet([PexAssumeUnderTest]DataNames target, List<string> value)
        {
            target.ValueNames = value;
            // TODO: ajouter des assertions à méthode DataNamesTest.ValueNamesSet(DataNames, List`1<String>)
        }
    }
}
