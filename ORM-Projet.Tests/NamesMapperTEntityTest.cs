using System.Data;
// <copyright file="NamesMapperTEntityTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Mapping;

namespace ORMProjet.Mapping.Tests
{
    [TestClass]
    [PexClass(typeof(NamesMapper<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class NamesMapperTEntityTest
    {

        [PexGenericArguments(typeof(object))]
        [PexMethod]
        public TEntity Map<TEntity>([PexAssumeUnderTest]NamesMapper<TEntity> target, DataRow row)
            where TEntity : class, new()
        {
            TEntity result = target.Map(row);
            return result;
            // TODO: ajouter des assertions à méthode NamesMapperTEntityTest.Map(NamesMapper`1<!!0>, DataRow)
        }
    }
}
