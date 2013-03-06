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
                Console.WriteLine(versionsResponse.error_code);
                Console.WriteLine(versionsResponse.message);
                Console.WriteLine(versionsResponse.is_public);
                if (!String.IsNullOrEmpty(versionsResponse.error_code))
                {
                    throw new Exception("Failed to get Version.");
                }
            }

        }
        [TestMethod]
        public void TestDiscoveryCall()
        {
            var keenTestClient = new KeenIO();
            var result = keenTestClient.GetDiscovery();
            foreach (var discoveryResponse in result)
            {
                Console.WriteLine(discoveryResponse.error_code);
                Console.WriteLine(discoveryResponse.message);
                Console.WriteLine(discoveryResponse.projects_resource_url);
                if (!String.IsNullOrEmpty(discoveryResponse.error_code))
                {
                    throw new Exception("Failed to get Directory.");
                }
            }

        }
        [TestMethod]
        public void TestProjectsCall()
        {
            var keenTestClient = new KeenIO();
            var result = keenTestClient.GetDiscovery();
            foreach (var projectsResponse in result)
            {
                Console.WriteLine(projectsResponse.error_code);
                Console.WriteLine(projectsResponse.message);
                Console.WriteLine(projectsResponse.projects_resource_url);
                if (!String.IsNullOrEmpty(projectsResponse.error_code))
                {
                    throw new Exception("Failed to get Directory.");
                }
            }

        }
    }
}
