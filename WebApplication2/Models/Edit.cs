using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class Edit
    {
        public double? Id { get; set; }
        public string Indicador { get; set; }
        public string Indicador_pl { get; set; }
        public int Week { get; set; }
        public string Region { get; set; }
        public string Valor { get; set; }
        public string Valor_pl { get; set; }
        public string linea { get; set; }

    }
}
