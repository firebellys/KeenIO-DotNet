using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace KeenClient_DotNet
{
    class KeenResponses
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class VersionsResponse
    {
        public bool is_public { get; set; }
        public string url { get; set; }
        public string version { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DiscoveryResponse
    {
        public string projects_resource_url { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }
    public class ProjectsResponse
    {
        public string api_key { get; set; }
        public List<Event> events { get; set; }
        public string events_url { get; set; }
        public string id { get; set; }
        public string saved_queries { get; set; }
        public string name { get; set; }
        public string queries_url { get; set; }
        public string url { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }
    public class Event
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ProjectRowResponse
    {
        public string api_key { get; set; }
        public List<Event> events { get; set; }
        public string events_url { get; set; }
        public string id { get; set; }
        public string saved_queries { get; set; }
        public string name { get; set; }
        public string queries_url { get; set; }
        public string url { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }

    public class GetEventResponse
    {
        public string name { get; set; }
        public Dictionary<string, string> properties { get; set; }
        public string url;

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }

    }

    public class GetEventCollectionResponse
    {
        public string name { get; set; }
        public Dictionary<string, string> properties { get; set; }
        public string url;

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }

    }
    public class InsertEventResponse
    {
        public List<InsertEventResponseStatus> items { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }

    public class InsertEventCollectionResponse
    {
        public List<InsertEventResponseStatus> items { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }

    public class InsertEventResponseStatus
    {
        public Dictionary<String, bool> status { get; set; }
    }

    public class EventProperties
    {
        public string name { get; set; }
        public string value { get; set; }
    }


}
