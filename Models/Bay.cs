using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Bay : Element
    {
        public int ConnectingElement1Id { get; set; }
        public int ConnectingElement2Id { get; set; }
        public int OwnerId { get; set; }
        public int VoltageId { get; set; }
        public string BayType { get; set; }

        public Element ConnectingElement1 { get; set; }
        public Element ConnectingElement2 { get; set; }
        public Voltage Voltage { get; set; }

        public Owner Owner { get; set; }

    }
}