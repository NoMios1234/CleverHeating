using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public int TemperatureMax { get; set; } 
        public int TemperatureMin { get; set; } 
        public string Position { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
    }
}
