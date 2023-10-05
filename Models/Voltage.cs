using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Voltage
    {
        public int VoltageId { get; set; }
        public int VoltageLevel { get; set; }

        // public ICollection<GeneratingUnit> GeneratingUnits { get; set; }
    }
}