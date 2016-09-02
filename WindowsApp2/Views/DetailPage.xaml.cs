﻿using WindowsApp2;
//using MasterDetailApp.ViewModels;
//using MasterDetailApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using WindowsApp2.Managers;
using System.Collections.ObjectModel;
using WindowsApp2.Models;
using Template10.Utils;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel;

namespace WindowsApp2.Views
{

    public sealed partial class DetailPage : Page
    {
       
        private static DependencyProperty s_itemProperty
            = DependencyProperty.Register("Item", typeof(ObservableCollection<Event>), typeof(DetailPage), new PropertyMetadata(null));

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
        


        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            var param = e.Parameter?.ToString();
            var service = Template10.Services.SerializationService.SerializationService.Json;
            var value = service.Deserialize<string>(param);

            Item = DataManager.EventList.Where((ev) => ev.name == value).FirstOrDefault();

            x = Item.coordinators[0];

          


        


            //var backStack = Frame.BackStack;
            //var backStackCount = backStack.Count;

            //if (backStackCount > 0)
            //{
            //    var masterPageEntry = backStack[backStackCount - 1];
            //    backStack.RemoveAt(backStackCount - 1);

            //    // Doctor the navigation parameter for the master page so it
            //    // will show the correct item in the side-by-side view.
            //    var modifiedEntry = new PageStackEntry(
            //        masterPageEntry.SourcePageType,
            //        Item.name,
            //        masterPageEntry.NavigationTransitionInfo
            //        );
            //    backStack.Add(modifiedEntry);
            //}

            // Register for hardware and software back request from the system
            //  SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            //   systemNavigationManager.BackRequested += DetailPage_BackRequested;
            //  systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
       //     systemNavigationManager.BackRequested -= DetailPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        //private void OnBackRequested()
        //{
        //    // Page above us will be our master view.
        //    // Make sure we are using the "drill out" animation in this transition.

        //    Frame.GoBack(new DrillInNavigationTransitionInfo());
        //}

        void NavigateBackForWideState(bool useTransition)
        {
            // Evict this page from the cache as we may not need it again.
            NavigationCacheMode = NavigationCacheMode.Disabled;

            if (useTransition)
            {
                Frame.GoBack(new EntranceNavigationTransitionInfo());
            }
            else
            {
                Frame.GoBack(new SuppressNavigationTransitionInfo());
            }
        }

        private bool ShouldGoToWideState()
        {
            return Window.Current.Bounds.Width >= 720;
        }

        private void PageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShouldGoToWideState())
            {
                // We shouldn't see this page since we are in "wide master-detail" mode.
                // Play a transition as we are navigating from a separate page.
                NavigateBackForWideState(useTransition: true);
            }
            else
            {
                // Realize the main page content.
                FindName("RootPanel");
            }

            Window.Current.SizeChanged += Window_SizeChanged;
        }

        private void PageRoot_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (ShouldGoToWideState())
            {
                // Make sure we are no longer listening to window change events.
                Window.Current.SizeChanged -= Window_SizeChanged;

                // We shouldn't see this page since we are in "wide master-detail" mode.
                NavigateBackForWideState(useTransition: false);
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            // open the Popup if it isn't open already 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }

        }




        //private void DetailPage_BackRequested(object sender, BackRequestedEventArgs e)
        //{
        //    // Mark event as handled so we don't get bounced out of the app.
        //    e.Handled = true;

        //    OnBackRequested();
        //}
    }
}
