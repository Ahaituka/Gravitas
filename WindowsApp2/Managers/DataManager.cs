using WindowsApp2.Models;
using System;
using System.Collections.Generic;
using WindowsApp2.ViewModels;
using Windows.Storage;
using WindowsApp2.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections;

namespace WindowsApp2.Managers
{
    public static class DataManager
    {

        private static readonly string FILE_NAME = "events.json";
        private static readonly StorageFolder _folder = ApplicationData.Current.LocalFolder;

        public static ObservableCollection<Event> EventList { get;  set; }
        public static ObservableCollection<CategoryViewModel> CategoryList { get; set; }
        public static bool IsReady { get; private set; }

        public static async Task<bool> LoadCacheAsync()
        {
            try
            {
                StorageFile file = await _folder.GetFileAsync(FILE_NAME);
                string data = await ContentManager.GetEventsJsonAsync(file);
                if (data == null)
                    return false;

                var events = JsonParser.TryGetEvents(data);
                if (events == null)
                    return false;
                var categories = GetCategories(events);

                EventList = events;
                CategoryList = categories;
                IsReady = true;
                return true;
            }
            catch
            {
                Reset();
                return false;
            }
        }

        public static async Task<StatusCode> RefreshDataAsync()
        {
            var response = await NetworkService.TryGetEventsJsonAsync();
            if (response.Code == StatusCode.Success)
            {
                var events = JsonParser.TryGetEvents(response.Content);
                if (events == null)
                    return StatusCode.UnknownError;
                var categories = GetCategories(events);

                EventList = events;
                CategoryList = categories;
                IsReady = true;

                await TrySaveDataAsync(response.Content);
            }
            return response.Code;
        }

        private static async Task<StatusCode> TrySaveDataAsync(string json)
        {
            if (IsReady == false)
                return StatusCode.NoData;
            try
            {
                StorageFile file = await _folder.CreateFileAsync(FILE_NAME, CreationCollisionOption.ReplaceExisting);
                await ContentManager.TryWriteEventsJsonAsync(file, json);
                return StatusCode.Success;
            }
            catch
            {
                return StatusCode.UnknownError;
            }
        }

        private static void Reset()
        {
            EventList = null;
            CategoryList = null;
            IsReady = false;
        }

        private static ObservableCollection<CategoryViewModel> GetCategories(IEnumerable<Event> eventList)
        {
            IEnumerable<string> categoryNames = eventList.Select((e) => e.subCategory).Distinct();
            var categories = new ObservableCollection<CategoryViewModel>();
            foreach (string c in categoryNames)
                categories.Add(new CategoryViewModel(c));
            return categories;
        }

        /*
        public static Event GetlistbyName(string names)
        {
           Event result = (Event)EventList.Select((e) => e.name = names);

           List<Event> newEvent = new List<Event>
          {
          new Event()
          {
              name=result.name,
              category=result.category,
              subCategory=result.subCategory,
              coordinators=result.coordinators,
              description=result.description,
              organization=result.organization,
              participationFee=result.participationFee,
              teamSize=result.teamSize,
           }

       };

            return newEvent[0];
        }
        */

    }
}