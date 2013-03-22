using System;
using System.Collections.Generic;

namespace KeenClient_DotNet.Requests
{
    class KeenRequests
    {
    }

    /// <summary>
    /// 
    /// </summary>

    public class InsertEventRequest : Dictionary<string, List<InsertEvent>>
    {
        
    }

    public class InsertEventCollectionRequest : InsertEvent
    {
        public string eventName { get; set; }
        public string collectionName { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class InsertEvent
    {
        public List<EventRequestProperties> properties { get; set; }
        public KeenTimeStamp keen { get; set; }
        public InsertEvent()
        {
            keen = new KeenTimeStamp();
            properties = new List<EventRequestProperties>();
        }
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

    public class QueryFilter: List<Filters>  
    {

    }
    
    public class Filters
    {
        public string PropertyName { get; set; }
        public string OperatorType { get; set; }
        public string PropertyValue { get; set; }
    }
    
    public class TimeFrame
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }


}

