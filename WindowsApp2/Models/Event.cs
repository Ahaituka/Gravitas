using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2.Models
{
    public class Event
    {
        public string name { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public List<string> organization { get; set; }
        public List<Coordinator> coordinators { get; set; }
        public string description { get; set; }
        public int teamSize { get; set; }
        public int participationFee { get; set; }

        public string chapterpath { get; set; }
    }




}
