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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Categories : Page
    {

        private  List<WindowsApp2.ViewModels.Categories> Category;
        public Categories()
        {
            this.InitializeComponent();
            Category = CategoryManager.GetCategory();
           
         }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var book = (Book)e.ClickedItem;
            //ResultTextBlock.Text = "You selected " + book.Title;
        }

    }
}
