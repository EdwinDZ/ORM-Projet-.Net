using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
// <copyright file="DataAttributesTest.GetDataNames.g.cs">${AuthorCopyright}</copyright>

using System;

namespace ORMProjet.Mapping.Tests
{
    public partial class DataAttributesTest
    {

[TestMethod]
[PexGeneratedBy(typeof(DataAttributesTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void GetDataNamesThrowsNullReferenceException593()
{
    List<string> list;
    list = this.GetDataNames((Type)null, (string)null);
}
    }
}
