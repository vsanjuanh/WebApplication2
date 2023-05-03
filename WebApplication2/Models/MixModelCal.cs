using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication2.Models
{
    public class MixmodelCal
    {
        public BdQuejasA BDQuejasA { get; set; }
        public BdQuejasB BDQuejasB { get; set; }
        public BdQuejasC BDQuejasC { get; set; }
        public BdQuejasTotales BDQuejasTotale { get; set; }
    }
}
