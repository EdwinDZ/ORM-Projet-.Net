// <copyright file="PropertyMapperTest.cs">${AuthorCopyright}</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Mapping;

namespace ORMProjet.Mapping.Tests
{
    [TestClass]
    [PexClass(typeof(PropertyMapper))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PropertyMapperTest
    {

        [PexMethod]
        public bool ParseBoolean(object value)
        {
            bool result = PropertyMapper.ParseBoolean(value);
            return result;
            // TODO: ajouter des assertions à méthode PropertyMapperTest.ParseBoolean(Object)
        }
    }
}
