using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.Models
{
    public class Room
    {
        public Room()
        {
            Equipments = new HashSet<Equipment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Temperature { get; set; }
        public double Square { get; set; }
        public int OfficeId { get; set; }
        public string PhotoFileName { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
