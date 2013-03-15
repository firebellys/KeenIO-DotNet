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
    public class InsertEventRequest : Dictionary<String, List<InsertEvent>>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class InsertEvent
    {
        public List<EventRequestProperties> properties { get; set; }
        public KeenTimeStamp keen { get; set; }
    }

    /// <summary>
    /// Only allows for base types, string, int, datetime, bool.
    /// </summary>
    public class EventRequestProperties
    {
        public string name { get; set; }
        public object value { get; set; }
    }
    public class KeenTimeStamp
    {
        public bool setTimeStamp { get; set; }
        public bool setDateTime { get; set; }
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


}

