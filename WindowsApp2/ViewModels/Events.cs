using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2.ViewModels
{
    public class Event
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Company { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", FullName, Company);
        }
    }
}
