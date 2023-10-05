using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class SubFilterBank : Element
    {
        public int FilterBankId { get; set; }

        public FilterBank FilterBank { get; set; }
    }
}