using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using ORMProjet.Mapping;
// <copyright file="NamesMapperTEntityTest.Map.g.cs">${AuthorCopyright}</copyright>

using System;

namespace ORMProjet.Mapping.Tests
{
    public partial class NamesMapperTEntityTest
    {

[TestMethod]
[PexGeneratedBy(typeof(NamesMapperTEntityTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void MapThrowsNullReferenceException271()
{
    object o;
    NamesMapper<object> s0 = new NamesMapper<object>();
    o = this.Map<object>(s0, (DataRow)null);
}
    }
}
