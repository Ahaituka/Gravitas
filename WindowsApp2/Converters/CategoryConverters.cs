using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using WindowsApp2.Managers;
using WindowsApp2.Models;
using WindowsApp2.ViewModels;
using WindowsApp2.Views;

namespace WindowsApp2.Converters
{
    public class CategoryToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string cat = value as string;
            if(cat != null)
            {
                if (String.Compare(cat, "events", true) == 0)
                    return Symbol.Play;
                else if (String.Compare(cat, "workshop", true) == 0)
                    return Symbol.Repair;
            }
            return Symbol.Add;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryToImageIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string cat = value as string;
            if (cat != null)
            {
                if (String.Compare(cat, "events", true) == 0)
                    return "ms-appx:///Assets/events.png";
                else if (String.Compare(cat, "workshop", true) == 0)
                    return "ms-appx:///Assets/workshop.png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Event ev = value as Event;
            if (ev != null)
            {
                return DataManager.CategoryList.First((c) => c.Name == ev.subCategory).CoverImage;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    
}

