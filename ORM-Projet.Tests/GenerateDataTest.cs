using System.Collections.Generic;
using System.Data;
// <copyright file="GenerateDataTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Mapping;

namespace ORMProjet.Mapping.Tests
{
    [TestClass]
    [PexClass(typeof(GenerateData))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GenerateDataTest
    {

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public DataSet ToDataSet<T>(List<T> list)
        {
            DataSet result = GenerateData.ToDataSet<T>(list);
            return result;
            // TODO: ajouter des assertions à méthode GenerateDataTest.ToDataSet(List`1<!!0>)
        }
    }
}
