using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class TrMonths
    {
        public double? Id { get; set; }
        public string Month { get; set; }
        public string Quarter { get; set; }
        public ICollection<Targets> Targets { get; set; }

        public TrWeeks trweek { get; set; }

    }
}
