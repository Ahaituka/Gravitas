using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsApp2.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;


        public HamburgerMenu _MyHamburgerMenu
        {
            get { return MyHamburgerMenu;     }

            set { MyHamburgerMenu = value;                    }
        }

        public Shell()
        {
            Instance = this;
            InitializeComponent();
        }


        public static void SetDiable()
        {

            Instance.MyHamburgerMenu.IsFullScreen = true;
            Instance.Visibility = Visibility.Collapsed;
            Instance.MyHamburgerMenu.Visibility = Visibility.Collapsed;
            Instance.MyHamburgerMenu.HamburgerButtonVisibility = Visibility.Collapsed;
            HamburgerMenu.IsFullScreen = true;

        }
        public static bool IsVisbible = false;

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }
    }
}

