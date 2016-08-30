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
        }

        private   void WebView_LoadCompleted(object sender, NavigationEventArgs e)
        {
            ProgressRing.Visibility = Visibility.Collapsed;

            //string functionString = String.Format("document.getElementById('section-title').innerText = 'Hello';");
            //await WebView.InvokeScriptAsync("eval", new string[] { functionString });

            
        }

        //private async void WebView_Loading(FrameworkElement sender, object args)
        //{
        //    string functionString = String.Format("document.getElementById('header').getElementsByTagName('h2')[0].innerHTML = 'new text';");
        //    await WebView.InvokeScriptAsync("eval", new string[] { functionString });

        //}
    }
}
