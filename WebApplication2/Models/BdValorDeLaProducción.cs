using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class BdValorDeLaProducción
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public string Week { get; set; }
        public double? ValorDeLaProducción { get; set; }
        public string Region { get; set; }
        public int? IdSem { get; set; }
        public double? Target { get; set; }
        public string Indicador { get; set; }
    }
}
