using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_Hospital_.Models
{
    public class Patient : Person
    {
        public DateTime Accepted { get; set; }
        public string DoctorName { get; set; }
        public List<Sickness> Sicknes { get; set; }
        public string[] Allergies { get; set; }
        public string Info { get; set; }

    }
}
