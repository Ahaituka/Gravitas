using NewsClient.Services.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using WindowsApp2.Models;

namespace WindowsApp2.ViewModels
{
    public class PastPageViewModel : ViewModelBase
    {

     


       
        public string CoverImage { get; set; }

        public PastPageViewModel()
        {
            
          
        }


         public static List<PastPageViewModel> GetPhotos()
        {
            var Photo = new List<PastPageViewModel>();

            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/1.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/12.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/13.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/14.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/15.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/16.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/2.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/20.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/3.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/4.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/6.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/7.jpg" });
            Photo.Add(new PastPageViewModel { CoverImage = "ms-appx:///Assets/9.jpg" });
          

            return Photo;
        }
    } 

    }

