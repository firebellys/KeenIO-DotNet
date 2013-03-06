using System;
using KeenClient_DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeenIODotNet_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVersionCall()
        {
            var keenTestClient = new KeenIO();
            var result = keenTestClient.GetVersions();
            foreach (var versionsResponse in result)
            {
                Console.Write(versionsResponse.error_code);
                Console.Write(versionsResponse.message);
                Console.Write(versionsResponse.is_public);
                if (!String.IsNullOrEmpty(versionsResponse.error_code))
                {
                    throw new Exception("Failed to get Version.");
                }
            }

        }
    }
}
