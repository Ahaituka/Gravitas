using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp2.Views
{
    /// <summary>
    /// A page that displays error if no data is loaded
    /// </summary>
    public sealed partial class Icheck : Page
    {
        #region Constructor
        public Icheck()
        {
            this.InitializeComponent();
            Stop();
        }

        #endregion

        #region Methods
        public async void Stop()
        {
            await Task.Delay(10000);

            ProgressRing.Visibility = Visibility.Collapsed;
            MyTextBox.Visibility = Visibility.Visible;

        } 
        #endregion

    }    
}
