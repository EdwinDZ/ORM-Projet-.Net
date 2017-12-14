using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using Microsoft.Pex.Framework.Generated;
// <copyright file="GenerateDataTest.ToDataSet.g.cs">${AuthorCopyright}</copyright>
using System;

namespace ORMProjet.Mapping.Tests
{
    public partial class GenerateDataTest
    {

[TestMethod]
[PexGeneratedBy(typeof(GenerateDataTest))]
public void ToDataSet604()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      List<int> list;
      DataSet dataSet;
      int[] ints = new int[2];
      list = new List<int>((IEnumerable<int>)ints);
      dataSet = this.ToDataSet<int>(list);
      disposables.Add((IDisposable)dataSet);
      disposables.Dispose();
    }
}
    }
}
