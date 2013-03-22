using System.Collections.Generic;

namespace KeenClient_DotNet.Responses
{
    class KeenResponses
    {    

    }

    public class KeenBaseResponse
    {
        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VersionsResponse : KeenBaseResponse
    {
        public bool is_public { get; set; }
        public string url { get; set; }
        public string version { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DiscoveryResponse : KeenBaseResponse
    {
        public string projects_resource_url { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }
    public class ProjectsResponse : KeenBaseResponse
    {
        public string api_key { get; set; }
        public List<Event> events { get; set; }
        public string events_url { get; set; }
        public string id { get; set; }
        public string saved_queries { get; set; }
        public string name { get; set; }
        public string queries_url { get; set; }
        public string url { get; set; }
    }
    public class Event
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ProjectRowResponse : KeenBaseResponse
    {
        public string api_key { get; set; }
        public List<Event> events { get; set; }
        public string events_url { get; set; }
        public string id { get; set; }
        public string saved_queries { get; set; }
        public string name { get; set; }
        public string queries_url { get; set; }
        public string url { get; set; }
    }

    public class GetEventResponse : KeenBaseResponse
    {
        public string name { get; set; }
        public Dictionary<string, string> properties { get; set; }
        public string url;

    }

    public class GetEventCollectionResponse : KeenBaseResponse
    {
        public string name { get; set; }
        public Dictionary<string, string> properties { get; set; }
        public string url;

    }
    public class InsertEventResponse : KeenBaseResponse
    {
        public List<InsertEventResponseStatus> items { get; set; }
    }

    public class InsertEventCollectionResponse : KeenBaseResponse
    {
        public List<InsertEventResponseStatus> items { get; set; }
    }

    public class InsertEventResponseStatus
    {
        public Dictionary<string, bool> status { get; set; }
    }

    public class EventProperties
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class PropertyResponse
    {
        public string property_name { get; set; }
        public string url { get; set; }
        public string type { get; set; }
    }
    public class QueriesResponse : Dictionary<string, string>
    {
        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }


    public class CountRepsonse : Dictionary<string, string>
    {
        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }
}
