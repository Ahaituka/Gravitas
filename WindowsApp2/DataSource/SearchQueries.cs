using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace WindowsApp2.DataSource
{
    public class SearchQueries
    {
        List<Customers> list = new List<Customers>();
        public List<Customers> GetResults(string query)
        {
            return list;
        }

        public async void SetResults()
        {
            list.Clear();
            Uri dataUri = new Uri("ms-appx:///DataSource/result.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["events"].GetArray();

            foreach(var item in jsonArray)
            {
                JsonObject groupObject = item.GetObject();
                list.Add(new Customers() { name = groupObject.GetNamedString("name") });
            }
        }

        public IEnumerable<Customers> GetMatchingCustomer(string query)
        {
            return list.Where(c => c.name.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1).OrderByDescending(c => c.name.StartsWith(query, StringComparison.CurrentCultureIgnoreCase));
        }

        public SearchQueries()
        {
            SetResults();
        }
    }
}
