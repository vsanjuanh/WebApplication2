using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class Ipfmpa
    {
        public double? Id { get; set; }
        public double? Semana { get; set; }
        public string Descripción { get; set; }
        public string Causa { get; set; }
        public string FactorAMejorar { get; set; }
        public string FechaCompromiso { get; set; }
        public string Quien { get; set; }
        public double? Avance { get; set; }
        public string Region { get; set; }
    }
}
