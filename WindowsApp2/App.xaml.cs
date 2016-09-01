using Windows.UI.Xaml;
using System.Threading.Tasks;
using WindowsApp2.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;
using Windows.Networking.PushNotifications;
using Microsoft.WindowsAzure.Messaging;
using Windows.UI.Popups;
using Template10GetTheSplashScreen.Controls;
using WindowsApp2.Managers;
using System.Diagnostics;
using WindowsApp2.Services;

using WindowsApp2.Views;
namespace WindowsApp2
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {

   

        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);
            Template10.Services.LoggingService.LoggingService.Enabled = true;

            #region App settings

            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
            
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            //  InitNotificationsAsync();
           // NavigationService.Navigate(typeof(Views.Error));
            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame 
             //   var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);

                // create modal root
            //    Window.Current.Content = new ModalDialog
            //    {
            //        DisableBackButtonWhenModal = true,
            //        Content = new Views.Shell(nav),
            //        ModalContent = new Views.Busy(),
            //    };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here
            await Task.Delay(TimeSpan.FromSeconds(6));

            await Windows.Storage.ApplicationData.Current.ClearAsync();
 
            await DataManager.LoadCacheAsync()
                ;
            Debug.WriteLine("Data Status: ", DataManager.IsReady);

            var x = NetworkService.IsInternet();

            if (DataManager.IsReady)
            {

                NavigationService.Navigate(typeof(AppStartupGuide.MainPage));
            }
            else if(!DataManager.IsReady)
            {
                //if(x)
                //{
                //    await DataManager.RefreshDataAsync();

                //    if(DataManager.IsReady)
                //    {

                //        NavigationService.Navigate(typeof(AppStartupGuide.MainPage));

                //    }

                //}

                if(!x)
                {
                    // NavigationService.Navigate(typeof(Views.Error));

                    Window.Current.Content = new Error();
                    NavigationService.Navigate(typeof(Error));
                }             
                }


         
            await Task.CompletedTask;
        }

        private async void InitNotificationsAsync()
        {
            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();


            var hub = new NotificationHub("GravitasHub", "Endpoint=sb://gravitashubnamesapce.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=Qlb9cobs7BGZhhJJ10uSjzb7kWcA7MUxgHqk3UHsiiM=");
            var result = await hub.RegisterNativeAsync(channel.Uri);

            // Displays the registration ID so you know it was successful
            //if (result.RegistrationId != null)
            //{
            //    var dialog = new MessageDialog("Registration successful: " + result.RegistrationId);
            //    dialog.Commands.Add(new UICommand("OK"));
            //    await dialog.ShowAsync();
            //}

        }
    }
}

