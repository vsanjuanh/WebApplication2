using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class Targets
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public string Indicador { get; set; }
        public string Region { get; set; }
        public double Value { get; set; }
        public TrMonths trmonths { get; set; }
    }
}
