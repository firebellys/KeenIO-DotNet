using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace KeenClient_DotNet
{
    class KeenRequests
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class InsertEventRequest : Dictionary<String, InsertEvent>
    {
        //public Dictionary<String, InsertEvent> properties { get; set; }
    }

    public class InsertEvent 
    {
        public List<EventRequestProperties> properties { get; set; }
        public KeenTimeStamp keen { get; set; }
    }

    public class KeenTimeStamp
    {
        public DateTime created_at { get; set; }
        public DateTime timestamp { get; set; }
    }
    public class InsertEventCollectionRequest
    {
        public List<InsertEvent> events { get; set; }
        public List<InsertEventRequest> nestedEvents { get; set; }
        public InsertEventCollectionRequest()
        {
            events = new List<InsertEvent>();
            nestedEvents = new List<InsertEventRequest>();
        }
    }
    public class EventRequestProperties
    {
        public string name { get; set; }
        public string value { get; set; }
    }

}

