using System;
using System.Collections.Generic;
using KeenClient_DotNet.Requests;
using KeenClient_DotNet.Responses;
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
        /// 
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
        /// <returns>A list of InsertEvenResponses</returns>
        public List<InsertEventResponse> InsertEvent(InsertEventRequest requestObject)
        {
            var js = new JsonSerializer();
            var tempsadsd = js.Serialize(requestObject);
            //Build the JSON from scratch as the serializer will break it.
            var outputstring = new System.Text.StringBuilder();
            outputstring.Append("{");

            var collectionCounter = 0;
            foreach (var item in requestObject)
            {
                outputstring.Append("\"").Append(item.Key).Append("\":[");

                var listOfEvents = item.Value;
                var eventCounter = 0;
                foreach (var singleEvent in listOfEvents)
                {
                    outputstring.Append("{");
                    if (singleEvent.keen != null && (singleEvent.keen.setTimeStamp || singleEvent.keen.setDateTime))
                    {
                        outputstring.Append("\"keen\":{");
                        if (singleEvent.keen.setDateTime)
                        {
                            outputstring.Append("\"created_at\":").Append(js.Serialize(singleEvent.keen.created_at));
                            if (singleEvent.keen.setTimeStamp)
                            {
                                outputstring.Append(",");
                            }
                        }
                        if (singleEvent.keen.setTimeStamp)
                        {
                            outputstring.Append("\"timestamp\":").Append(js.Serialize(singleEvent.keen.timestamp));
                        }
                        outputstring.Append("},");
                    }

                    var propCounter = 0;
                    foreach (var properties in singleEvent.properties)
                    {
                        outputstring.Append("\"" + properties.name + "\"").Append(":");
                        var serializedString = js.Serialize(properties.value);
                        outputstring.Append(serializedString);
                        if (singleEvent.properties.Count > 1 && propCounter != singleEvent.properties.Count - 1)
                        {
                            outputstring.Append(",");
                        }
                        propCounter++;
                    }
                    outputstring.Append("}");
                    if (listOfEvents.Count > 1 && eventCounter != listOfEvents.Count - 1)
                    {
                        outputstring.Append(",");
                    }
                    eventCounter++;
                }
                outputstring.Append("]");
                if (requestObject.Count > 1 && collectionCounter != requestObject.Count - 1)
                {
                    outputstring.Append(",");
                }
                collectionCounter++;

            }
            outputstring.Append("}");

            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/events?api_key=" + _apiKey, Method.POST);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddBody(outputstring.ToString());
            _restClient.Authenticator = new HttpBasicAuthenticator("api_key", _apiKey);
            var deserializedReply = _restClient.Execute<List<InsertEventResponse>>(request);
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

        /// <summary>
        /// Inserts the event collection.
        /// </summary>
        /// <param name="requestObject">The request object.</param>
        /// <returns></returns>
        public List<InsertEventCollectionResponse> InsertEventCollection(InsertEventCollectionRequest requestObject)
        {
            var js = new JsonSerializer();
            var tempsadsd = js.Serialize(requestObject);
            //Build the JSON from scratch as the serializer will break it.
            var outputstring = new System.Text.StringBuilder();
            outputstring.Append("{");
            outputstring.Append("\"").Append(requestObject.eventName).Append("\":{");

            if (requestObject.keen != null && (requestObject.keen.setTimeStamp || requestObject.keen.setDateTime))
            {
                outputstring.Append("\"keen\":{");
                if (requestObject.keen.setDateTime)
                {
                    outputstring.Append("\"created_at\":").Append(js.Serialize(requestObject.keen.created_at));
                    if (requestObject.keen.setTimeStamp)
                    {
                        outputstring.Append(",");
                    }
                }
                if (requestObject.keen.setTimeStamp)
                {
                    outputstring.Append("\"timestamp\":").Append(js.Serialize(requestObject.keen.timestamp));
                }
                outputstring.Append("},");
            }

            var propCounter = 0;
            foreach (var properties in requestObject.properties)
            {
                outputstring.Append("\"" + properties.name + "\"").Append(":");
                var serializedString = js.Serialize(properties.value);
                outputstring.Append(serializedString);
                if (requestObject.properties.Count > 1 && propCounter != requestObject.properties.Count - 1)
                {
                    outputstring.Append(",");
                }
                propCounter++;
            }
            outputstring.Append("}}");
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/events/" + requestObject.collectionName + "?api_key=" + _apiKey, Method.POST);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddBody(outputstring.ToString());
            _restClient.Authenticator = new HttpBasicAuthenticator("api_key", _apiKey);
            var deserializedReply = _restClient.Execute<List<InsertEventCollectionResponse>>(request);
            return deserializedReply.Data;
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public List<PropertyResponse> GetProperty(string collectionName, string propertyName)
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/events/"+collectionName+"/properties/"+propertyName+"?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<PropertyResponse>>(request);
            return deserializedReply.Data;
        }

        public List<QueriesResponse> GetQueries()
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/queries?api_key=" + _apiKey, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<List<QueriesResponse>>(request);
            return deserializedReply.Data;
        }


        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        public CountRepsonse GetCount(QueryRequest countRequest)
        {
            var request = new RestRequest("/" + _apiVersion + "/projects/" + _projectKey + "/queries/count?api_key=" + _apiKey+"&event_collection="+countRequest.QueryCollectionName, Method.GET);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            var response = _restClient.Execute(request);
            var content = response.Content;
            var deserializedReply = _restClient.Execute<CountRepsonse>(request);
            return deserializedReply.Data;
        }
    
        private void GetCountUnique()
        {
        }
        private void GetMinimum()
        {
        }
        private void GetMaximum()
        {
        }
        private void GetAverage()
        {
        }
        private void GetSum()
        {
        }
        private void SelectUnique()
        {
        }
        private void Extraction()
        {
        }
        private void FunnelResource()
        {
        }
        private void SavedQueriesList()
        {
        }
        private void SavedQueryRow()
        {
        }
        private void SavedQuieryRowResult()
        {
        }
    }
}
