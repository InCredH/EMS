using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class GeneratingStation
    {
        public int GeneratingStationId { get; set; }
        public string GeneratingStationName { get; set; }
        public int InstalledCapacity { get; set; }
        public int MVARCapacity { get; set; }
        public int GeneratingStationClassificationId { get; set; }
        public int GeneratingStationTypeId { get; set; }
        public int FuelId { get; set; }


        public GeneratingStationClassification GeneratingStationClassification { get; set; }
        public GeneratingStationType GeneratingStationType { get; set; }
        public Fuel Fuel { get; set; }
    }
}