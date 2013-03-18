# Keen IO Client
Installing
======================================
Take the KeenIO.dll and drop into your project folder somewhere.
Add it to your references.

Full Documentation.
======================================
[Jump to Current Documentation](https://github.com/firebellys/KeenIO-DotNet/tree/Dev/Documentation/Help)
Sync this folder locally.
Load the Index.html file in a browser.
Documentation will load in browser.

Inserting Bulk events.
======================================
reate a new client 

    var keenClient = new KeenIO();

Set your parameters.

    keenClient.SetAPIKey("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
    keenClient.SetProjectKey("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

Create a new request

    var newRequest = new InsertEventRequest();

Create a new event

    var samepleEvents = new InsertEvent();

Create a property group

    var props = new EventRequestProperties {name = "sameple1", value = "value 2"};
    samepleEvents.properties.Add(props);

Stack your events into a list.

    var listOfEvents = new List<InsertEvent> {samepleEvents, samepleEvents};

Add your events list to a specific collection. The first param is the name, the second is the list of event.

    newRequest.Add("Purchases", listOfEvents);
    newRequest.Add("Memes", listOfEvents);
    newRequest.Add("Dogs", listOfEvents);

Call the client synchronous

    var result = keenTestClient.InsertEvent(newRequest);

Sort through the reply.

    foreach (var eventResponse in result)
    {
     ...
    }


Inserting Single events.
======================================
Create a new client 

    var keenClient = new KeenIO();

Set your parameters.

    keenClient.SetAPIKey("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
    keenClient.SetProjectKey("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

Create a new request to insert an event

    var newRequest = new InsertEventCollectionRequest();

Customize the timestamps (Optional)

    newRequest.keen = new KeenTimeStamp { created_at = DateTime.Now, timestamp = DateTime.Now, setDateTime = true, setTimeStamp = true };

Set the name of the event you want to insert/update.

    newRequest.eventName = "MyTestEvents";

Create a new property group and add it to the collection. Repeated to show Data Types
    
    var props = new EventRequestProperties {name = "Items_Sold", value = 111111};
    newRequest.properties.Add(props);
    props = new EventRequestProperties {name = "Item_name", value = "MyItem"};
    newRequest.properties.Add(props);
    props = new EventRequestProperties {name = "Items_SoldDate", value = DateTime.Now};
    newRequest.properties.Add(props);
    props = new EventRequestProperties {name = "is_ItemSold", value = false};
    newRequest.properties.Add(props);

Call client synchronous

    var result = keenTestClient.InsertEventCollection(testRequest);

Sort through results set.

    foreach (var eventResponse in result)
        {
    ...
        }
