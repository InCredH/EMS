using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Compensator : Element
    {
        public int PercentageVariableCompensation { get; set; }
        public int PercentageFixedCompensation { get; set; }
    }
}