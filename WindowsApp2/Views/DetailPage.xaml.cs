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

namespace WindowsApp2.Views
{

    public sealed partial class DetailPage : Page
    {
        /*
        public ObservableCollection<Event> EventList { get; set; }
        */

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

        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            var param = e.Parameter?.ToString();
            var service = Template10.Services.SerializationService.SerializationService.Json;
            var value = service.Deserialize<string>(param);




            //ObservableCollection<Event> eventDataWrapper =  EventList.Select((x) => x.name = (string)e.Parameter)

            //var characters = (Event)eventDataWrapper.ToList();

            //foreach (var character in characters)
            //{
            //    Item.Add(character);


            //}



            /*
            this.EventList = DataManager.EventList;
            // Parameter is item ID
            IEnumerable<Event> categoryNames = EventList.Where(x => x.name == (string)e.Parameter);
            var categories = new ObservableCollection<Event>(categoryNames);
            */

            //            var linqResults = foos.Where(f => f.Name == "Widget");

            //var observable = new ObservableCollection<Foo>(linqResults);

            // Item = DataManager.EventList.First((ev) => ev.name == (string)e.Parameter);
            Item = DataManager.EventList.Where((ev) => ev.name == value).FirstOrDefault();

      //       MyTextBox.Text = Item.name;
            

            //List<Event> Source = Item.ToList<Event>();
            //Source


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

        //private void PageRoot_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (ShouldGoToWideState())
        //    {
        //        // We shouldn't see this page since we are in "wide master-detail" mode.
        //        // Play a transition as we are navigating from a separate page.
        //        NavigateBackForWideState(useTransition: true);
        //    }
        //    else
        //    {
        //        // Realize the main page content.
        //        FindName("RootPanel");
        //    }

        //    Window.Current.SizeChanged += Window_SizeChanged;
        //}

        //private void PageRoot_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    Window.Current.SizeChanged -= Window_SizeChanged;
        //}

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

        //private void DetailPage_BackRequested(object sender, BackRequestedEventArgs e)
        //{
        //    // Mark event as handled so we don't get bounced out of the app.
        //    e.Handled = true;

        //    OnBackRequested();
        //}
    }
}
