using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp22.Models
{
   
public class Coordinator
{
    public string phone { get; set; }
    public string reg_no { get; set; }
    public string _id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}

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
}

public class CharacterDataWrapper
    {
    public List<Event> events { get; set; }
}
}
