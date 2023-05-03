using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication2.Models
{
    public partial class BdAccidente
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public string Week { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public double NúmeroDeEventos { get; set; }
        public string Region { get; set; }
        public int IdSem { get; set; }
        public int Target { get; set; }
        public string Indicador { get; set; }

        public DateTime date = DateTime.Now;
    }

}
