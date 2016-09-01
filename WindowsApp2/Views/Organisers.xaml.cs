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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Organisers : Page
    {
        public Organisers()
        {
            this.InitializeComponent();

            bool x = NetworkService.IsInternet();

            if (!x)
            {
                //var service = this.Frame.GetNavigationService();
                //await service.NavigateAsync(typeof(Views.Icheck));

                Stop();

            }
        }


        private async void WebView_LoadCompleted(object sender, NavigationEventArgs e)
        {
            ProgressRing.Visibility = Visibility.Collapsed;
            string functionString = String.Format("document.getElementById('portfolio').getElementsByTagName('h2')[0].innerHTML = 'Team Gravitas 16';");


            //string functionString = String.Format("document.getElementById('section-title').innerText = 'Hello';");
            await WebView.InvokeScriptAsync("eval", new string[] { functionString });


        }



        public async void    WebView_Loading_1(FrameworkElement sender, object args)
        {
            
        }

        public async void Stop()
        {
            await Task.Delay(10000);

            ProgressRing.Visibility = Visibility.Collapsed;
            
            MyTextBox.Visibility = Visibility.Visible;

        }



        //private async void WebView_Loading(FrameworkElement sender, object args)
        //{
        //    string functionString = String.Format("document.getElementById('header').getElementsByTagName('h2')[0].innerHTML = 'new text';");
        //    await WebView.InvokeScriptAsync("eval", new string[] { functionString });

        //}
    }
}
