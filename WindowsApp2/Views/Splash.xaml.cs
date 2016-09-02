using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsApp2.Views
{
    public sealed partial class Splash : UserControl
    {
        #region Constructor
        public Splash(SplashScreen splashScreen)
        {
            InitializeComponent();
            Window.Current.SizeChanged += (s, e) => Resize(splashScreen);
            RingStoryboard.Begin();
            Resize(splashScreen);
        }
        #endregion

        #region Methods
        private void Resize(SplashScreen splashScreen)
        {
            if (splashScreen.ImageLocation.Top == 0)
            {
                MyImage.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                MyCanvas.Background = null;
                MyImage.Visibility = Visibility.Visible;
            }
            MyImage.Height = splashScreen.ImageLocation.Height;
            MyImage.Width = splashScreen.ImageLocation.Width;
            MyImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
            MyImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
        }

        private void DoubleAnimationUsingKeyFrames_Completed(object sender, object e)
        {

        } 
        #endregion
    }
}

