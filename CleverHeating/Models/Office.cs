using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.Models
{
    public class Office
    {
        public Office()
        {
            Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Square { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoFileName { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
