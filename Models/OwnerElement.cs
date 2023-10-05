using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class OwnerElement
    {
        public int OwnerElementId { get; set; }
        public int OwnerId { get; set; }
        public int ElementId { get; set; }

        public Owner Owner { get; set; }
        public Element Element { get; set; }
    }
}