# Keen IO Client
Installing
======================================
Take the KeenIO.dll and drop into your project folder somewhere.
Add it to your references.

Inserting bulk events.
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
