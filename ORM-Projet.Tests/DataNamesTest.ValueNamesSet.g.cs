using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ORMProjet.Mapping;
// <copyright file="DataNamesTest.ValueNamesSet.g.cs">${AuthorCopyright}</copyright>

using System;

namespace ORMProjet.Mapping.Tests
{
    public partial class DataNamesTest
    {

[TestMethod]
[PexGeneratedBy(typeof(DataNamesTest))]
public void ValueNamesSet332()
{
    DataNames dataNames;
    string[] ss = new string[0];
    dataNames = new DataNames(ss);
    this.ValueNamesSet(dataNames, (List<string>)null);
    Assert.IsNotNull((object)dataNames);
    Assert.IsNull(dataNames._valueNames);
}
    }
}
