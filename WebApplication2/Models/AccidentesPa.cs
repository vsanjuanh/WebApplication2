using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
#nullable disable

namespace WebApplication2.Models
{
    public partial class AccidentesPa
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public double Semana { get; set; }
        public string Descripción { get; set; }
        public string? Causa { get; set; }
        public string FactorAMejorar { get; set; }
        public string FechaCompromiso { get; set; }
        public string Quien { get; set; }
        public double Avance { get; set; }
        public string Region { get; set; }
        public string Indicador { get; set; }
        public string WeekPA { get; set; }
    }
}
