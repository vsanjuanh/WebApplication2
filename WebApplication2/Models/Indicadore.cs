using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Indicadore
    {
        public double? Id { get; set; }
        public string Indicador { get; set; }
        public string Area { get; set; }
        public string Referencia { get; set; }
    }
}
