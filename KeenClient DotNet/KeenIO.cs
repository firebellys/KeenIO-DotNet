using System;
using System.Collections.Generic;
using RestSharp;

namespace KeenClient_DotNet
{
    public class KeenIO
    {

        private readonly RestClient _restClient = new RestClient(KeenContants.SERVER_ADDRESS);

        /// <summary>
        /// Versionses this instance.
        /// </summary>
        /// <returns>A list of Version replies.</returns>
        public List<VersionsResponse> GetVersions()
        {
            var request = new RestRequest("/?api_key=" + KeenContants.API_KEY, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<VersionsResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Gets the discovery.
        /// </summary>
        /// <returns></returns>
        public List<DiscoveryResponse> GetDiscovery()
        {
            var request = new RestRequest("/" + KeenContants.API_VERSION + "?api_key=" + KeenContants.API_KEY, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<DiscoveryResponse>>(request);
            return deserializedReply.Data;
        }
        public List<ProjectsResponse> GetProjects()
        {
            var request = new RestRequest("/" + KeenContants.API_VERSION + "/projects?api_key=" + KeenContants.API_KEY, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<ProjectsResponse>>(request);
            return deserializedReply.Data;
        }
        public List<ProjectRowResponse> GetProjectRow()
        {
            var request = new RestRequest("/" + KeenContants.API_VERSION + "/projects/" + KeenContants.PROJECT_KEY + "?api_key=" + KeenContants.API_KEY, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<ProjectRowResponse>>(request);
            return deserializedReply.Data;
        }
        public List<EventResponse> GetEvent(Method requestType)
        {
            switch (requestType)
            {
                case Method.GET:
                    var request = new RestRequest("/" + KeenContants.API_VERSION + "/projects/" + KeenContants.PROJECT_KEY + "/events?api_key=" + KeenContants.API_KEY, Method.GET);
                    request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
                    _restClient.Authenticator = new HttpBasicAuthenticator("api_key", KeenContants.API_KEY);
                    var response = _restClient.Execute(request);
                    var content = response.Content;
                    var deserializedReply = _restClient.Execute<List<EventResponse>>(request);
                    return deserializedReply.Data;
                case Method.POST:

                default:
                    throw new Exception("Broke in Get Event");
            }


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
