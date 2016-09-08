using NewsClient.Services.DataService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using WindowsApp2.Models;

namespace WindowsApp2.ViewModels
{
    public class OrganiserViewModel :ViewModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }

         public OrganiserViewModel()
        {
            //Name = name;
            //Description = null;
            //if (Name == "Applied Engineering")
            //    CoverImage = "ms-appx:///Assets/appliedengineering.png";
            //else if (Name == "Workshop")
            //    CoverImage = "ms-appx:///Assets/workshop.jpg";
            //else if (Name == "Premium")
            //    CoverImage = "ms-appx:///Assets/premium.png";
            //else if (Name == "Informal")
            //    CoverImage = "ms-appx:///Assets/informals.png";
            //else if (Name == "Bio / Chemical")
            //    CoverImage = "ms-appx:///Assets/bioxyn.png";
            //else if (Name == "Builtrix")
            //    CoverImage = "ms-appx:///Assets/builtrix.png";
            //else if (Name == "Bits and Bytes")
            //    CoverImage = "ms-appx:///Assets/bitsandbytes.png";
            //else if (Name == "Quiz")
            //    CoverImage = "ms-appx:///Assets/gravitasquizseries.png";
            //else if (Name == "Online")
            //    CoverImage = "ms-appx:///Assets/online.png";
            //else if (Name == "Circuitrix")
            //    CoverImage = "ms-appx:///Assets/circuitrix.png";
            //else if (Name == "Speaking / Management")
            //    CoverImage = "ms-appx:///Assets/management.png";
            //else if (Name == "Robotics")
            //    CoverImage = "ms-appx:///Assets/robomania.png";
            //else
            //    CoverImage = "ms-appx:///Assets/7.png";
           
        }


  
            public static ObservableCollection<OrganiserViewModel> GetOrganisers()
            {
                var Organizers = new ObservableCollection<OrganiserViewModel>();

                Organizers.Add(new  OrganiserViewModel{ Name = "Applied Engineering", Description = "Futurum", CoverImage = "ms-appx:///Assets/grav.jpg" });
                Organizers.Add(new OrganiserViewModel { Name = "Bioxyn", Description = "Sequiter Que", CoverImage = "ms-appx:///Assets/grav.jpg" });
                Organizers.Add(new OrganiserViewModel { Name = "Circuitrix", Description = "Tempor", CoverImage = "ms-appx:///Assets/grav.jpg" });
                //Organizers.Add(new Category { Name = "Bits and Bytes", Description = "Option", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Builtrix", Description = "Accumsan", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Quiz Series", Description = "Legunt Xaepius", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Robomania", Description = "Eleifend", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Online", Description = "Vero Tation", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Premium", Description = "Jack Tibbles", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Informals", Description = "Tuffy Tibbles", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Management", Description = "Volupat", CoverImage = "ms-appx:///Assets/7.png" });
                //Organizers.Add(new Category { Name = "Workshops", Description = "Est Possim", CoverImage = "ms-appx:///Assets/7.png" });

                return Organizers;
            
        }
    
    }
}
