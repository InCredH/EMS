using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Substation
    {
        public int SubstationId { get; set; }
        public int VoltageId { get; set; }
        public int LocationId { get; set; }
        public string SubstationType { get; set; }

        public Voltage Voltage { get; set; }
        public Location Location { get; set; }

        public ICollection<OwnerSubstation> OwnerSubstations { get; set; }
    }
}