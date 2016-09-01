//using NewsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using WindowsApp2.Managers;
using WindowsApp2.Models;

namespace NewsClient.Services.DataService
{
    public class DataService
    {
        FileHelper _fileHelper;
        List<Event> _favorites;
       // NewsService.NewsService _newsService;


        private static List<Event> _articles;


        public async Task<List<Event>> GetEventAsync()
        {
            if (_articles == null)
                _articles = DataManager.EventList.ToList<Event>();
            if (_articles == null)
                _articles = new List<Event>();
            return _articles;
        }

        public async Task<Event> GetEventAsync(string id)
        {
            return (await GetEventAsync()).FirstOrDefault(x => x.name.Equals(id));
        }

        #region favorites

        public static event EventHandler<List<Event>> FavoritesChanged;

        public async Task<List<Event>> GetFavoritesAsync()
        {
            if (_favorites == null)
                _favorites = await _fileHelper.ReadFileAsync<List<Event>>(nameof(_favorites));
            if (_favorites == null)
                _favorites = new List<Event>();
            return _favorites;
        }

        public async Task<List<Event>> AddToFavoritesAsync(Event article)
        {
            var favorites = await GetFavoritesAsync();
            favorites.RemoveAll(x => x.name.Equals(article.name));
            favorites.Add(article);
            return await SaveFavoritesAsync(favorites);
        }

        public async Task<List<Event>> RemoveFromFavoritesAsync(Event article)
        {
            var favorites = await GetFavoritesAsync();
            favorites.RemoveAll(x => x.name.Equals(article.name));
            return await SaveFavoritesAsync(favorites);
        }

        async Task<List<Event>> SaveFavoritesAsync(List<Event> favorites)
        {
            if (await _fileHelper.WriteFileAsync(nameof(_favorites), favorites))
                _favorites = favorites;
            else
                throw new Exception("Failed to save.");
            FavoritesChanged?.Invoke(this, _favorites);
            return _favorites;
        }

        #endregion

        public static Event Sample(object headline = null)
        {
            return new Event
            {
                name = $"Article{headline} headline",
                description = 
                        "The quick brown fox jumps over the lazy dog Now is the time for all good men to come the aid of their country."

                   
            };
        }
    }
}
