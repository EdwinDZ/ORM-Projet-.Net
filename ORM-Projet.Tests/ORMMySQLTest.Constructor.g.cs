using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMProjet.Connection;
// <copyright file="ORMMySQLTest.Constructor.g.cs">${AuthorCopyright}</copyright>

using System;

namespace ORMProjet.Connection.Tests
{
    public partial class ORMMySQLTest
    {

[TestMethod]
[PexGeneratedBy(typeof(ORMMySQLTest))]
[PexRaisedException(typeof(ArgumentException))]
public void ConstructorThrowsArgumentException499()
{
    ORMMySQL oRMMySQL;
    oRMMySQL = this.Constructor("蛏↛⁆");
}

[TestMethod]
[PexGeneratedBy(typeof(ORMMySQLTest))]
public void Constructor795()
{
    ORMMySQL oRMMySQL;
    oRMMySQL = this.Constructor((string)null);
}
    }
}
