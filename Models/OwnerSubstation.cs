using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class OwnerSubstation
    {
        public int OwnerSubstationId { get; set; }
        public int OwnerId { get; set; }
        public int SubstationId { get; set; }

        public Owner Owner { get; set; }
        public Substation Substation { get; set; }
    }
}