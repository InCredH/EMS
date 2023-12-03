using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class FilterBank
    {
        public int FilterBankId { get; set; }
        public int VoltageId { get; set; }
        public int ElementId { get; set; }
        public int MVARCapacity { get; set; }
        public bool IsSwitchable { get; set; }

        public Voltage? Voltage { get; set; }
        public Element? Element { get; set; }
    }
}