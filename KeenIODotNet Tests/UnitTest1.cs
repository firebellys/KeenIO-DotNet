using System;
using System.Collections.Generic;
using KeenClient_DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace KeenIODotNet_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVersionCall()
        {
            var keenTestClient = new KeenIO();
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");
            var result = keenTestClient.GetVersions();
            if (result == null)
            {
                throw new Exception("No data.");
            }
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
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");
            var result = keenTestClient.GetDiscovery();
            if (result == null)
            {
                throw new Exception("No data.");
            }
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
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");
            var result = keenTestClient.GetDiscovery();
            if (result == null)
            {
                throw new Exception("No data.");
            }
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

        [TestMethod]
        public void TestProjectRowCall()
        {
            var keenTestClient = new KeenIO();
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");
            var result = keenTestClient.GetDiscovery();
            if (result == null)
            {
                throw new Exception("No data.");
            }
            foreach (var projectRowResponse in result)
            {
                Console.WriteLine(projectRowResponse.error_code);
                Console.WriteLine(projectRowResponse.message);
                Console.WriteLine(projectRowResponse.projects_resource_url);
                if (!String.IsNullOrEmpty(projectRowResponse.error_code))
                {
                    throw new Exception("Failed to get Directory.");
                }
            }

        }
        [TestMethod]
        public void TestGetEventCall()
        {
            var keenTestClient = new KeenIO();
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");
            var result = keenTestClient.GetEvent();
            if (result == null)
            {
                throw new Exception("No data.");
            }
            foreach (var eventResponse in result)
            {
                Console.WriteLine(eventResponse.error_code);
                Console.WriteLine(eventResponse.message);
                if (!String.IsNullOrEmpty(eventResponse.error_code))
                {
                    throw new Exception("Failed to get Directory.");
                }
            }
        }
        [TestMethod]
        public void TestGetEventCollectionCall()
        {
            var keenTestClient = new KeenIO();
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");
            var result = keenTestClient.GetEventCollection("TestEvents");
            if (result == null)
            {
                throw new Exception("No data.");
            }
            foreach (var eventResponse in result)
            {
                Console.WriteLine(eventResponse.error_code);
                Console.WriteLine(eventResponse.message);
                if (!String.IsNullOrEmpty(eventResponse.error_code))
                {
                    throw new Exception("Failed to get Directory.");
                }
            }
        }
        [TestMethod]
        public void TestInsertEvent()
        {
            var keenTestClient = new KeenIO();
            keenTestClient.SetAPIKey("1FA4C5505E789A12EA97BBC73394F830");
            keenTestClient.SetProjectKey("e159853dd9a9463892c5354e1830c59b");

            var testRequest = new InsertEventRequest();


            var samepleEvents = new InsertEvent();
            samepleEvents.keen = new KeenTimeStamp() { created_at = DateTime.Now, timestamp = DateTime.Now };

            var props = new EventRequestProperties();
            props.name = "sameple1";
            props.value = "value 2";

            samepleEvents.properties = new List<EventRequestProperties>();
            samepleEvents.properties.Add(props);
            props.name = "sameple4";
            props.value = "value 4";
            samepleEvents.properties.Add(props);
            props.name = "sameple5";
            props.value = "value 6";
            samepleEvents.properties.Add(props);

            testRequest.Add("Purchases", samepleEvents);
            testRequest.Add("Memes", samepleEvents);
            testRequest.Add("Dogs", samepleEvents);

            var result = keenTestClient.InsertEvent(testRequest);
            if (result == null)
            {
                throw new Exception("No data.");
            }
            foreach (var eventResponse in result)
            {
                Console.WriteLine(eventResponse.error_code);
                Console.WriteLine(eventResponse.message);
                if (!String.IsNullOrEmpty(eventResponse.error_code))
                {
                    throw new Exception("Failed to get Directory.");
                }
            }
        }
    }
}
