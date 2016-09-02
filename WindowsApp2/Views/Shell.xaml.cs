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
        #region Properties
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;
        public HamburgerMenu _MyHamburgerMenu
        {
            get { return MyHamburgerMenu; }

            set { MyHamburgerMenu = value; }
        }

        #endregion

        #region Constructos
        public Shell()
        {
            Instance = this;
            InitializeComponent();
        }
        #endregion

        #region Methods
        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        } 
        #endregion
    }
}

