using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsApp2.ViewModels;
using WindowsApp2.Managers;
using System.Collections.ObjectModel;
using WindowsApp2.Models;
using Template10.Utils;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp2.Views
{
    /// <summary>
    /// Categoy page displays the list of all categories
    /// </summary>
    public sealed partial class CategoryPage : Page
    {
        #region Properties
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        #endregion

        #region Constructos
        public CategoryPage()
        {
            this.InitializeComponent();
            if (DataManager.IsReady == true)
                Categories = DataManager.CategoryList;
            else
                ; // Can give error
            this.DataContext = this;
        }
        #endregion

        #region Methods
        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var parameter = (CategoryViewModel)e.ClickedItem;
            var service = this.Frame.GetNavigationService();
            
            await service.NavigateAsync(typeof(Views.MasterDetailPage), string.Format("{0}#{1}", "category", parameter.Name));     
        }
        #endregion

        private void asb_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //  ObservableCollection<Event> Names = DataManager.EventList;
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var x = StringComparison.OrdinalIgnoreCase;
                List<Event> eventList = DataManager.EventList.ToList();
                var matchingEvents = eventList.Where(s => s.name.StartsWith(sender.Text, x)).Select((s) => s.name);

                var count = matchingEvents.Count();
                if(count!=0)
                sender.ItemsSource = matchingEvents.ToList();

                else
                    sender.ItemsSource = new List<string>() ;
            }



        }

        private async void asb_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var service = this.Frame.GetNavigationService();

            if (args.ChosenSuggestion != null)
                await service.NavigateAsync(typeof(Views.MasterDetailPage), string.Format("{0}#{1}", "event", (args.ChosenSuggestion as Event).name));
            else
                await service.NavigateAsync(typeof(Views.MasterDetailPage), string.Format("{0}#{1}", "event", args.QueryText as string));
        }
        /*
        private async void asb_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

            var eventChosen = args.SelectedItem as string;

            var service = this.Frame.GetNavigationService();
            await service.NavigateAsync(typeof(Views.MasterDetailPage), );
        }
        */
    }
}
