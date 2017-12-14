using System.Collections.Generic;
using ORMProjet.Configuration;
// <copyright file="DboMapperTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Mapping;

namespace ORMProjet.Mapping.Tests
{
    [TestClass]
    [PexClass(typeof(DboMapper))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DboMapperTest
    {

        [PexMethod]
        public bool Execute(string request, List<DboParameter> parameters)
        {
            bool result = DboMapper.Execute(request, parameters);
            return result;
            // TODO: ajouter des assertions à méthode DboMapperTest.Execute(String, List`1<DboParameter>)
        }
    }
}
