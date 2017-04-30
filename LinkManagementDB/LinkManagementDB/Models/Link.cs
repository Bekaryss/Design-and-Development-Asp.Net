using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkManagementDB.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Link(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
    }
}
