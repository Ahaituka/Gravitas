using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using WindowsApp2.Models;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;


namespace WindowsApp2.Facades
{
   public  class EventFacade
    {

        public static async Task<EventDataWrapper> GetEventListByCategoryAsync(string category)
        {
            //Assemble the Url

            string url = String.Format("THe api link");

            //Call out to api
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url);
            //Response -> string/json ->deserialize
            var jsonMessage = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(EventDataWrapper));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonMessage));
            var result = (EventDataWrapper)serializer.ReadObject(ms);
            return result;

        }


        public static async Task PopulateEventListAsync(ObservableCollection<EventDataWrapper> eventList , string category)
        {
            try
            {
                var eventDataWrapper = await GetEventListByCategoryAsync(category);

                var characters = eventDataWrapper;  //.data.results;

                
                }
            
            catch (Exception)
            {
                return;
            }
        }

    }
}
