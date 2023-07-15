using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Models
{
    public class EventModel
    {
        public string title { get; set; }
        public System.Runtime.InteropServices.JavaScript.JSType.Date start { get; set; }
        public System.Runtime.InteropServices.JavaScript.JSType.Date end { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public bool allDay { get; set; }

        

    }
}
