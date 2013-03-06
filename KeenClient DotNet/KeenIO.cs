using System.Collections.Generic;
using RestSharp;

namespace KeenClient_DotNet
{
    public class KeenIO
    {
        //public static HttpWebClient _KeenWebClient;
        /// <summary>
        /// Versionses this instance.
        /// </summary>
        public List<VersionsResponse> GetVersions()
        {

            var httpReply = new RestClient(UrLs.VersionURL);

            var request = new RestRequest("/?api_key=1FA4C5505E789A12EA97BBC73394F830", Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);

            var response = httpReply.Execute(request);
            var content = response.Content;
            var response2 = httpReply.Execute<List<VersionsResponse>>(request);

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
