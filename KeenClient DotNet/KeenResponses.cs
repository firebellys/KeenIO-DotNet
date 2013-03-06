using System;
using System.Collections.Generic;
using System.Linq;
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
        public string error_code { get; set; }
        public string message { get; set; }
    }
    public class DiscoveryResponse
    {
        public string projects_resource_url { get; set; }
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
        public string error_code { get; set; }
        public string message { get; set; }
    }
    public class Event
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
