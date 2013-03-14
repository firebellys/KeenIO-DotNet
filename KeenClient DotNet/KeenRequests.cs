using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeenClient_DotNet
{
    class KeenRequests
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class InsertEventRequest
    {
        public List<InsertEvent> events { get; set; }
        public List<InsertEventRequest> nestedEvents { get; set; }
        public InsertEventRequest()
        {
            events = new List<InsertEvent>();
            nestedEvents = new List<InsertEventRequest>();
        }
    }

    public class InsertEvent
    {
        public List<KeenTimeStamp> keen { get; set; }
        public Dictionary<string, object> properties { get; set; }
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

}

