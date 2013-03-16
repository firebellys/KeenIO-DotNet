﻿using System;
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

    public class InsertEventRequest : Dictionary<String, List<InsertEvent>>
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
    //public partial class InsertEventCollectionRequest
    //{
    //    public List<InsertEvent> events { get; set; }
    //    public List<InsertEventRequest> nestedEvents { get; set; }
    //    public InsertEventCollectionRequest()
    //    {
    //        events = new List<InsertEvent>();
    //        nestedEvents = new List<InsertEventRequest>();
    //    }
    //}


}

