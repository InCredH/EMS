using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Bus : Element
    {
        public int SubstationId { get; set; }
        public string BusType { get; set; }

        public Substation Substation { get; set; }
    }
}