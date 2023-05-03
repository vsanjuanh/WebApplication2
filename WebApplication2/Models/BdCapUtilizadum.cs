using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace WebApplication2.Models
{
    public partial class BdCapUtilizadum
    {
        [ForeignKey("Id")]
        public int? Id { get; set; }
        public string Week { get; set; }
        public double? CapacidadUtilizada { get; set; }
        public string Region { get; set; }
        public int? IdSem { get; set; }
        public double? Target { get; set; }
        public string Indicador { get; set; }
    }
}
