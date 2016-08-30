using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsApp2.ViewModels;
using WindowsApp2.Managers;
using System.Collections.ObjectModel;
using WindowsApp2.Models;
using Template10.Utils;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryPage : Page
    {

        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public CategoryPage()
        {
            this.InitializeComponent();
            if (DataManager.IsReady == true)
                Categories = DataManager.CategoryList;
            else
                ; // Can give error
            this.DataContext = this;
        }

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var parameter = (CategoryViewModel)e.ClickedItem;
            var service = this.Frame.GetNavigationService();
            await service.NavigateAsync(typeof(Views.MasterDetailPage), parameter.Name);

      // Frame.Navigate(typeof(MasterDetailPage));
        }

    }
}
