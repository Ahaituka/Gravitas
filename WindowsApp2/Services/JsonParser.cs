using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.Data.Json;
using System.Collections.ObjectModel;

using WindowsApp2.Models;
using System.Threading.Tasks;
using Windows.Storage;

namespace WindowsApp2.Services
{
    public static class JsonParser
    {
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

                //var xg = GetfilesAsync();

                //string g = xg.ToString();

                foreach (var x in eventList)
                {
                    x.chapterpath = String.Format("ms-appx:///Assets/ChapterLogos/{0}.png",x.organization[0].ToLower());
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
