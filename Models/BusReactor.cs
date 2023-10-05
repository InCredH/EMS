using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class BusReactor : Element
    {
        public int BusId { get; set; }
        public int MVARCapacity { get; set; }

        public Bus Bus { get; set; }
    }
}