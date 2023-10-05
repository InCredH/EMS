using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Transformer : Element
    {
        public int SubstationType { get; set; }
        public int Voltage1Id { get; set; }
        public int Voltage2Id { get; set; }
        public int MVACapacity { get; set; }

        public Voltage Voltage1 { get; set; }
        public Voltage Voltage2 { get; set; }
    }
}