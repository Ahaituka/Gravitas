using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2.ViewModels
{
   
        public class Categories
        {
           
            public string Name { get; set; }
            public string Description { get; set; }
            public string CoverImage { get; set; }
        }



        public class CategoryManager
        {
            public static List<Categories> GetCategory()
            {
                var Categry = new List<Categories>();

                Categry.Add(new Categories {  Name = "Applied Engineering", Description = "Futurum", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Bioxyn", Description = "Sequiter Que", CoverImage = "ms-appx:///Assets/7.png"  });
                Categry.Add(new Categories {  Name = "Circuitrix", Description = "Tempor", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Bits and Bytes", Description = "Option", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Builtrix", Description = "Accumsan", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Quiz Series", Description = "Legunt Xaepius", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Robomania", Description = "Eleifend", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Online", Description = "Vero Tation", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Premium", Description = "Jack Tibbles", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Informals", Description = "Tuffy Tibbles", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Management", Description = "Volupat", CoverImage = "ms-appx:///Assets/7.png" });
                Categry.Add(new Categories {  Name = "Workshops", Description = "Est Possim", CoverImage = "ms-appx:///Assets/7.png" });
            

                return Categry;
            }
        }


    }

