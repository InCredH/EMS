using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int ConstituentId { get; set; }

        public Constituent Constituent { get; set; }

        public ICollection<OwnerSubstation> OwnerSubstations { get; set; }
        public ICollection<OwnerElement> OwnerElements { get; set; }
    }
}