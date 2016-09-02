using System;
using WindowsApp2.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using WindowsApp2.DataSource;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;

namespace WindowsApp2.Views
{
    public sealed partial class MainPage : Page
    {

        #region Constructor
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        #endregion

        #region Methods
        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var newCoreAppView = CoreApplication.CreateNewView();
            var appView = ApplicationView.GetForCurrentView();
            await newCoreAppView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, async () =>
            {
                var window = Window.Current;
                var newAppView = ApplicationView.GetForCurrentView();

                var frame = new Frame();
                window.Content = frame;

                frame.Navigate(typeof(Favourites));
                window.Activate();
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.Default, appView.Id, ViewSizePreference.Default);

            });
        }

        //        /*
        //       /// <summary>
        //       /// This event gets fired anytime the text in the TextBox gets updated.
        //       /// It is recommended to check the reason for the text changing by checking against args.Reason
        //       /// </summary>
        //       /// <param name="sender">The AutoSuggestBox whose text got changed.</param>
        //       /// <param name="args">The event arguments.</param>
        //       private void asb_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        //       {
        //           //We only want to get results when it was a user typing, 
        //           //otherwise we assume the value got filled in by TextMemberPath 
        //           //or the handler for SuggestionChosen
        //              if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        //               {
        //                   var matchingEvents = EventsList.GetMatchingEvent(sender.Text);

        //                   sender.ItemsSource = matchingContacts.ToList();
        //               }


        //           if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        //           {
        //               var matchingCustomer = searchQueries.GetMatchingCustomer(sender.Text);
        //               sender.ItemsSource = matchingCustomer.ToList();
        //           }
        //       }


        //        /// <summary>
        //        /// This event gets fired when:
        //        ///     * a user presses Enter while focus is in the TextBox
        //        ///     * a user clicks or tabs to and invokes the query button (defined using the QueryIcon API)
        //        ///     * a user presses selects (clicks/taps/presses Enter) a suggestion
        //        /// </summary>
        //        /// <param name="sender">The AutoSuggestBox that fired the event.</param>
        //        /// <param name="args">The args contain the QueryText, which is the text in the TextBox, 
        //        /// and also ChosenSuggestion, which is only non-null when a user selects an item in the list.</param>
        //        private void asb_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        //        {


        //            if (args.ChosenSuggestion != null)
        //            {
        //                SelectCustomer(args.ChosenSuggestion as Customers);
        //            }
        //            else
        //            {
        //                var matchingCustomer = searchQueries.GetMatchingCustomer(args.QueryText);
        //                if (matchingCustomer.Count() >= 1)
        //                    SelectCustomer(matchingCustomer.FirstOrDefault());
        //            }

        //            /* if (args.ChosenSuggestion != null)
        //             {
        //                 //User selected an item, take an action on it here
        //                 //    SelectContact(args.ChosenSuggestion as Contact);
        //             }
        //             else
        //             {
        //                 //Do a fuzzy search on the query text
        //                 /*  var matchingContacts = ContactSampleDataSource.GetMatchingContacts(args.QueryText);

        //                   if (matchingContacts.Count() >= 1)
        //                   {
        //                       //Choose the first match
        //                       SelectContact(matchingContacts.FirstOrDefault());
        //                   }
        //                   else
        //                   {
        //                       NoResults.Visibility = Visibility.Visible;
        //                   }*/
        //        }

        //        private void SelectCustomer(Customers customers)
        //        {
        //            if (customers != null)
        //                asb.Text = customers.name;
        //        }


        //   /// <summary>
        //   /// This event gets fired as the user keys through the list, or taps on a suggestion.
        //   /// This allows you to change the text in the TextBox to reflect the item in the list.
        //   /// Alternatively you can use TextMemberPath.
        //   /// </summary>
        //   /// <param name="sender">The AutoSuggestBox that fired the event.</param>
        //   /// <param name="args">The args contain SelectedItem, which contains the data item of the item that is currently highlighted.</param>
        //   private void asb_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        //   {
        //       /*   var contact = args.SelectedItem as Contact;

        //          sender.Text = string.Format("{0} ({1})", contact.FullName, contact.Company);*/
        //}



        //    /// <summary>
        //    /// This 
        //    /// </summary>
        //    /// <param name="contact"></param>
        //    /*private void SelectContact(Contact contact)
        //    {
        //        if (contact != null)
        //        {
        //            ContactDetails.Visibility = Visibility.Visible;
        //            ContactName.Text = contact.FullName;
        //            ContactCompany.Text = contact.Company;
        //        }

        //    }*/

        #endregion

    }

 }


