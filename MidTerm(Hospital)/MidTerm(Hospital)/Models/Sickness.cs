using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_Hospital_.Models
{
    public class Sickness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Stage Stages { get; set; }
    }
    public enum Stage
    {
        First,
        Second,
        Third,
        Last
    }
}
