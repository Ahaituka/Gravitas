using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Template10.Common.BootStrapper;
using WindowsApp2.Services;
using Template10.Services.NavigationService;
using Template10.Utils;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp2.Views
{
    /// <summary>
    /// Page that display detials of team gravitas
    /// </summary>
    public sealed partial class Organisers : Page
    {
        #region Constructor
        public Organisers()
        {
            this.InitializeComponent();

            bool x = NetworkService.IsInternet();

            if (!x)
            {
                Stop();
            }
        }
        #endregion

        #region Methods
        //private async void WebView_LoadCompleted(object sender, NavigationEventArgs e)
        //{
        //    ProgressRing.Visibility = Visibility.Collapsed;

        //    string functionString = String.Format("document.getElementsByClassName('stupid_icons')[0].style.visibility = 'hidden';document.getElementsByClassName('grey-text text-lighten-4 right')[0].style.visibility = 'hidden';document.getElementsByClassName('nav-wrapper z-depth-3')[0].style.visibility = 'hidden';document.getElementsByClassName('dock-container2')[0].style.visibility = 'hidden';");
        //    await WebView.InvokeScriptAsync("eval", new string[] { functionString });


        //    //functionString = String.Format("document.getElementsByClassName('dock-container2')[0].style.visibility = 'hidden';");
        //    //await WebView.InvokeScriptAsync("eval", new string[] { functionString });


        //}

        public async void Stop()
        {
            await Task.Delay(10000);

            ProgressRing.Visibility = Visibility.Collapsed;

            MyTextBox.Visibility = Visibility.Visible;

        }
        #endregion

        private void WebView_LoadCompleted(FrameworkElement sender, object args)
        {

        }

        //private async void WebView_Loading(FrameworkElement sender, object args)
        //{
        //    ProgressRing.Visibility = Visibility.Collapsed;

        //    string functionString = String.Format("document.getElementsByClassName('stupid_icons')[0].style.visibility = 'hidden';document.getElementsByClassName('grey-text text-lighten-4 right')[0].style.visibility = 'hidden';document.getElementsByClassName('nav-wrapper z-depth-3')[0].style.visibility = 'hidden';document.getElementsByClassName('dock-container2')[0].style.visibility = 'hidden';");
        //    await WebView.InvokeScriptAsync("eval", new string[] { functionString });


        //}

        private async void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {

            ProgressRing.Visibility = Visibility.Collapsed;

            string functionString = String.Format("document.getElementsByClassName('stupid_icons')[0].style.visibility = 'hidden';document.getElementsByClassName('grey-text text-lighten-4 right')[0].style.visibility = 'hidden';document.getElementsByClassName('nav-wrapper z-depth-3')[0].style.visibility = 'hidden';document.getElementsByClassName('dock-container2')[0].style.visibility = 'hidden';");
            try
            {
                await WebView.InvokeScriptAsync("eval", new string[] { functionString });
            }
            catch (Exception ex)
            {
                WebView.DefaultBackgroundColor = Colors.White;
                MyTextBox.Visibility = Visibility.Visible;
            }


            //functionString = String.Format("document.getElementsByClassName('dock-container2')[0].style.visibility = 'hidden';");
            //await WebView.InvokeScriptAsync("eval", new string[] { functionString });
        }
    }
}
