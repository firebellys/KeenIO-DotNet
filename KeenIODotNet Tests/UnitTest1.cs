using System;
using KeenClient_DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeenIODotNet_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var keenTestClient = new KeenClient_DotNet.KeenIO();
            keenTestClient.Average();
        }
    }
}
