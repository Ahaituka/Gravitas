using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WindowsApp2.Views
{
    public sealed partial class SettingsPage : Page
    {
        #region Properties
        Template10.Services.SerializationService.ISerializationService _SerializationService;
        #endregion

        #region Constructor
        public SettingsPage()
        {
            InitializeComponent();
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
        }
        #endregion

        #region Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_SerializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }
        #endregion

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            EmailMessage emailMessage = new EmailMessage()
            {
                Subject = "FeedBack Regarding  Windows App: ",
                Body = ""
            };
            emailMessage.To.Add(new EmailRecipient() { Address = "bitloks@gmail.com" });
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        private async void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // TODO.
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

        private async void Ellipse_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            string uriToLaunch = @"https://github.com/VinayGupta23";
            var uri = new Uri(uriToLaunch);
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }


    }

}
