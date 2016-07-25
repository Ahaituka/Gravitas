using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2.DataSource
{
   public class Customers
    {
        public string name;
        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }
}
