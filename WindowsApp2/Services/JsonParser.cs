using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.Data.Json;
using System.Collections.ObjectModel;

using WindowsApp2.Models;

namespace WindowsApp2.Services
{
    public static class JsonParser
    {
        /*
        private static void AssignStringList(JsonObject obj, string arrayKey, List<string> targetList)
        {
            if (obj.GetNamedValue(arrayKey).ValueType == JsonValueType.Null)
                return;

            foreach (JsonValue val in obj.GetNamedArray(arrayKey))
                targetList.Add(val.GetString());
        }
        */

        public static ObservableCollection<Event> TryGetEvents(string eventsJson)
        {
            try
            {
                List<Event> events = new List<Event>();
                JsonArray jArr = JsonObject.Parse(eventsJson).GetNamedArray("events");
                string arrayString = jArr.Stringify();

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Event>), 
                    new List<Type> { typeof(Event), typeof(List<string>), typeof(Coordinator), typeof(List<Coordinator>) });
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(arrayString));
                var eventList = new ObservableCollection<Event>((List<Event>)jsonSerializer.ReadObject(ms));

                foreach (var x in eventList)
                {
                    if(x.organization[0]=="SME")
                    {

                        x.chapterpath = "ms-appx:///Assets/appliedengineering.png";                   

                     }


                    else

                        x.chapterpath = "ms-appx:///Assets/workshop.png";

                }

               
                return eventList;
            }
            catch
            {
                return null;
            }
        }

    }
            
}
