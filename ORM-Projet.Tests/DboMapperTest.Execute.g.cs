using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ORMProjet.Configuration;
// <copyright file="DboMapperTest.Execute.g.cs">${AuthorCopyright}</copyright>

using System;

namespace ORMProjet.Mapping.Tests
{
    public partial class DboMapperTest
    {

[TestMethod]
[PexGeneratedBy(typeof(DboMapperTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void ExecuteThrowsNullReferenceException600()
{
    bool b;
    b = this.Execute((string)null, (List<DboParameter>)null);
}
    }
}
