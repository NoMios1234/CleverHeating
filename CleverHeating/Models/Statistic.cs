using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public uint WorkedTime { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

    }
}
