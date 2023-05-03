using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication2.Models
{
    public partial class ValordelaproduccionPA
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public double Semana { get; set; }
        public string Descripción { get; set; }
        public string Causa { get; set; }
        public string FactiraMejorar { get; set; }
        public string FechaCompromiso { get; set; }
        public string Quien { get; set; }
        public double Avance { get; set; }
        public string Region { get; set; }
        public string Indicador { get; set; }

        public DateTime date = DateTime.Now;
    }

}
