using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartSubscribe { get; set; }
        public DateTime EndSubscribe { get; set; }
        public string UserId { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual User User { get; set; }     
    }
}
