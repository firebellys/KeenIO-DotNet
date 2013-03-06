using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KeenClient_DotNet
{
    public class KeenIO
    {
        //public static HttpWebClient _KeenWebClient;
        /// <summary>
        /// Versionses this instance.
        /// </summary>
        public VersionsResponse GetVersions()
        {
            var reply = new VersionsResponse();
            var httpReply = new RestSharp.RestClient(UrLs.VersionURL);
            var request = new RestRequest("resource/{id}", Method.POST);
            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", 123); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("header", "value");

            // execute the request
            RestResponse response = httpReply.Execute(request);
            var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            RestResponse<VersionsResponse> response2 = httpReply.Execute<VersionsResponse>(request);
            return response2.Data;
        }

        public void GetDiscovery()
        {

        }
        public void GetProjects()
        {
        }
        public void GetProjectRow()
        {
        }
        public void GetEvent()
        {
        }
        public void GetEventCollection()
        {
        }
        public void GetQueries()
        {
        }
        public void GetCount()
        {
        }
        public void GetCountUnique()
        {
        }
        public void GetMinimum()
        {
        }
        public void GetMaximum()
        {
        }
        public void GetAverage()
        {
        }
        public void GetSum()
        {
        }
        public void SelectUnique()
        {
        }
        public void Extraction()
        {
        }
        public void FunnelResource()
        {
        }
        public void SavedQueriesList()
        {
        }
        public void SavedQueryRow()
        {
        }
        public void SavedQuieryRowResult()
        {
        }
    }

    public class KeenUser
    {
        public string APIKEY { get; set; }

    }
}
