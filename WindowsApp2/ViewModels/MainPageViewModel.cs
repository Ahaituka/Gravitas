using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using NewsClient.Services.DataService;
using WindowsApp2.Models;

namespace WindowsApp2.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private DataService _dataService;


        private Event _article;
        public Event Article { get { return _article; } set { Set(ref _article, value); } }



        public async void UpdateIsFavorite()
        {
            var favorites = await _dataService.GetFavoritesAsync();
            IsFavorite = favorites.Any(x => x.name.Equals(Article?.name));
            RaisePropertyChanged(nameof(IsFavorite));
        }

        public bool IsFavorite { get; set; }


        public async void AddToFavorites()
        {
            await _dataService.AddToFavoritesAsync(Article);
            UpdateIsFavorite();
        }

        public async void RemoveFromFavorites()
        {
            await _dataService.RemoveFromFavoritesAsync(Article);
            UpdateIsFavorite();
        }



        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Value = "Designtime value";
            }
        }

        string _Value = "Gas";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                Value = suspensionState[nameof(Value)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), Value);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

