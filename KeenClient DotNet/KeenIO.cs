using System;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using RestSharp.Serializers;

namespace KeenClient_DotNet
{
    public class KeenIO
    {
        private string _apiKey = "";
        private string _projectKey = "";
        private string _apiVersion = "3.0";

        /// <summary>
        /// Sets the API key.
        /// </summary>
        /// <param name="key">The key. Expects a GUID</param>
        /// <returns></returns>
        public bool SetAPIKey(string key)
        {
            try
            {
                _apiKey = key;
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Sets the API version.
        /// </summary>
        /// <param name="version">The version. Expects "3.0" format.</param>
        /// <returns></returns>
        public bool SetAPIVersion(string version)
        {
            try
            {
                _apiVersion = version;
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Sets the project key.
        /// </summary>
        /// <param name="key">The key. Expects a GUID</param>
        /// <returns></returns>
        public bool SetProjectKey(string key)
        {
            try
            {
                _projectKey = key;
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// The _rest client
        /// </summary>
        private readonly RestClient _restClient = new RestClient(KeenContants.SERVER_ADDRESS);

        /// <summary>
        /// Versionses this instance.
        /// </summary>
        /// <returns>A list of Version replies.</returns>
        public List<VersionsResponse> GetVersions()
        {
            var request = new RestRequest("/?api_key=" + _apiKey, Method.GET);
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
            var request = new RestRequest("/" + _apiVersion + "?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<DiscoveryResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        public List<ProjectsResponse> GetProjects()
        {
            var request = new RestRequest("/" + _apiVersion + "/projects?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<ProjectsResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Gets the project row.
        /// </summary>
        /// <returns></returns>
        public List<ProjectRowResponse> GetProjectRow()
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<ProjectRowResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <returns></returns>
        public List<GetEventResponse> GetEvent()
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/events?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            _restClient.Authenticator = new HttpBasicAuthenticator("api_key", _apiKey);
            var deserializedReply = _restClient.Execute<List<GetEventResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Sets the event.
        /// </summary>
        /// <returns></returns>
        public List<SetEventResponse> InsertEvent(InsertEventRequest requestObject)
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/events?api_key=" + _apiKey, Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddBody(requestObject);
            _restClient.Authenticator = new HttpBasicAuthenticator("api_key", _apiKey);
            var deserializedReply = _restClient.Execute<List<SetEventResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Gets the event collection.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns></returns>
        public List<GetEventCollectionResponse> GetEventCollection(string collectionName)
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/events/" + collectionName + "?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            _restClient.Authenticator = new HttpBasicAuthenticator("api_key", _apiKey);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<GetEventCollectionResponse>>(request);
            return deserializedReply.Data;
        }
        public void InsertEventCollection()
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
}
