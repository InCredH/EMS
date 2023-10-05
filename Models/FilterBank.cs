using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class FilterBank : Element
    {
        public int VoltageId { get; set; }
        public int MVARCapacity { get; set; }

        public Voltage Voltage { get; set; }
    }
}