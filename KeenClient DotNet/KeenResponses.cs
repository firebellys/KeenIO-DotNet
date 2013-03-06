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
    public class VersionsResponse
    {
        public bool is_public { get; set; }
        public string url { get; set; }
        public string version { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }
    }
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

    //    [
    //  {
    //    "name": "TestEvents", 
    //    "properties": {
    //      "erikTest.timestamp": "string", 
    //      "itemid": "num", 
    //      "keen.created_at": "datetime", 
    //      "keen.timestamp": "datetime", 
    //      "type": "string", 
    //      "x_coord": "num", 
    //      "y_coord": "num"
    //    }, 
    //    "url": "/3.0/projects/e159853dd9a9463892c5354e1830c59b/events/TestEvents"
    //  }
    //]
    public class EventResponse
    {
        public List<FullEvent> FullEvents { get; set; }

        // Error containers
        public string error_code { get; set; }
        public string message { get; set; }

    }
    public class FullEvent
    {
        public string name { get; set; }
        public List<eventProps> properties { get; set; }
        public string url;
    }
    [DataContract]
    public class eventProps
    {

        public int quantity { get; set; }
        [DataMember(Name = "item.id")]
        public string itemID { get; set; }
        [DataMember(Name = "screen.name")]
        public string screenName { get; set; }

        public string user { get; set; }
    }


}
