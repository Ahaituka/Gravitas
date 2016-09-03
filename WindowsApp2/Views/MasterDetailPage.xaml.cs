using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Utils;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using WindowsApp2.Managers;
using WindowsApp2.Models;
using WindowsApp2.ViewModels;

namespace WindowsApp2.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        #region Properties
        private static DependencyProperty s_itemProperty
          = DependencyProperty.Register("Item", typeof(ObservableCollection<Event>), typeof(MasterDetailPage), new PropertyMetadata(null));

        public static DependencyProperty ItemProperty
        {
            get { return s_itemProperty; }
        }

        public Event Item
        {
            get { return (Event)GetValue(s_itemProperty); }
            set { SetValue(s_itemProperty, value); }
        }



        private static DependencyProperty s_xProperty
           = DependencyProperty.Register("x", typeof(ObservableCollection<Coordinator>), typeof(MasterDetailPage), new PropertyMetadata(null));

        public static DependencyProperty xProperty
        {
            get { return s_xProperty; }
        }

        public Coordinator x
        {
            get { return (Coordinator)GetValue(s_xProperty); }
            set { SetValue(s_xProperty, value); }
        }




        private static DependencyProperty s_HeaderProperty
         = DependencyProperty.Register("Header", typeof(ObservableCollection<Event>), typeof(MasterDetailPage), new PropertyMetadata(null));

        public static DependencyProperty HeaderProperty
        {
            get { return s_HeaderProperty; }
        }

        public Event Header
        {
            get { return (Event)GetValue(s_HeaderProperty); }
            set { SetValue(s_HeaderProperty, value); }
        }

        private Event _lastSelectedItem;
        #endregion

        #region Constructor
        public MasterDetailPage()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            var param = e.Parameter?.ToString();
            var service = Template10.Services.SerializationService.SerializationService.Json;
            var value = service.Deserialize<string>(param);



            var EventList = MasterListView.ItemsSource as ObservableCollection<Event>;
            var CategoryList = MasterListView.ItemsSource as ObservableCollection<Event>;

            if (value is string && !string.IsNullOrEmpty(value))
            {
                CategoryList = DataManager.EventList.Where((x) => x.name == value).ToObservableCollection<Event>();
                //EventList = DataManager.EventList;
                EventList = CategoryList;

                if(EventList.Count==0)
                {

                    CategoryList = DataManager.EventList.Where((x) => x.subCategory == value).ToObservableCollection<Event>();
                    //EventList = DataManager.EventList;
                    EventList = CategoryList;
                    Header = EventList[0];
                    MasterListView.ItemsSource = EventList;
                }
                else
                {



                    Header = EventList[0];
                    MasterListView.ItemsSource = EventList;

                    Item = EventList[0];                    
                    x = Item.coordinators.Where((item) => Item.name == value).FirstOrDefault();
                   //lastSelectedItem = clickedItem;


                }


             

            }


         

            else if (EventList == null)
            {

                CategoryList = DataManager.EventList.Where((x) => x.subCategory == value).ToObservableCollection<Event>();
                //EventList = DataManager.EventList;
                EventList = CategoryList;
                Header = EventList[0];

                MasterListView.ItemsSource = EventList;
            }


            else if (e.Parameter != null)
            {   // Parameter is item ID
                var id = (string)e.Parameter;
                _lastSelectedItem =
                    EventList.Where((item) => item.name == id).FirstOrDefault();
                Header = EventList[0];


            }


            UpdateForVisualState(AdaptiveStates.CurrentState);

            // Don't play a content transition for first item load.
            // Sometimes, this content will be animated as part of the page transition.
            DisableContentTransitions();

            base.OnNavigatedTo(e);


        }
        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }
        private async void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && _lastSelectedItem != null)
            {
                // Resize down to the detail item. Don't play a transition.
                var service = this.Frame.GetNavigationService();


                await service.NavigateAsync(typeof(Views.DetailPage), _lastSelectedItem.name, new SuppressNavigationTransitionInfo());

                //Frame.Navigate(typeof(DetailPage), _lastSelectedItem.name, new SuppressNavigationTransitionInfo());
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(MasterListView, isNarrow);
            if (DetailContentPresenter != null)
            {
                EntranceNavigationTransitionInfo.SetIsTargetElement(DetailContentPresenter, !isNarrow);
            }
        }
        private async void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            //var EventList = MasterListView.ItemsSource as ObservableCollection<Event>;
            //if (EventList == null)
            //{
            //    EventList = DataManager.EventList;
            //    MasterListView.ItemsSource = EventList;
            //Item = EventList.Where((item) => item.name == (Event)e).FirstOrDefault();

            var clickedItem = (Event)e.ClickedItem;
            Item = clickedItem;
            x = Item.coordinators.Where((item) => Item.name == clickedItem.name).FirstOrDefault();
            _lastSelectedItem = clickedItem;
            if (AdaptiveStates.CurrentState == NarrowState)
            {
                // Use "drill in" transition for navigating from master list to detail view
                // Frame.Navigate(typeof(DetailPage), clickedItem.name, new DrillInNavigationTransitionInfo());

                var service = this.Frame.GetNavigationService();

                await service.NavigateAsync(typeof(Views.DetailPage), clickedItem.name, new DrillInNavigationTransitionInfo());
            }
            else
            {
                // Play a refresh animation when the user switches detail items.
                EnableContentTransitions();
            }
        }
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            // Assure we are displaying the correct item. This is necessary in certain adaptive cases.
            MasterListView.SelectedItem = _lastSelectedItem;
        }
        private void EnableContentTransitions()
        {
            DetailContentPresenter.ContentTransitions.Clear();
            DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }
        private void DisableContentTransitions()
        {
            if (DetailContentPresenter != null)
            {
                DetailContentPresenter.ContentTransitions.Clear();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            // open the Popup if it isn't open already 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }

        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            // MainPageViewModel.AddToFavorites();
        }
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }
        private async void SymbolIcon_Tapped(object sender, RoutedEventArgs e)
        {
            EmailMessage emailMessage = new EmailMessage()
            {
                Subject = "App Feedback " + Package.Current.DisplayName + " ",
                Body = "First Line\r\nSecondLine"
            };

            emailMessage.To.Add(new EmailRecipient() { Address = x.email });
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);

        }
        private async void SymbolIcon_Tapped_1(object sender, RoutedEventArgs e)
        {
            var uriSkype = new Uri(@"Skype:(9952549997)?call");

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriSkype, promptOptions);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }


        } 
        #endregion
    }
}
