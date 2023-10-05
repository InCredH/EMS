using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class GeneratingUnit : Element
    {
        public int GeneratingStationId { get; set; }
        public int InstalledCapacity { get; set; }
        public int VoltageId { get; set; }
        public int GeneratingTransformerHVVoltageId { get; set; }

        public GeneratingStation GeneratingStation { get; set; }
        public Voltage Voltage { get; set; }
        public Voltage GeneratingTransformerHVVoltage { get; set; }
    }
}