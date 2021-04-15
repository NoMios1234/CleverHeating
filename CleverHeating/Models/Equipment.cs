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
        public int TemperatureMax { get; set; } // max температура обогрева
        public int TemperatureMin { get; set; } // min температура обогрева
        public string Position { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
    }
}
