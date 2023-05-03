using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class TrDates
    {
        [ForeignKey("Id")]
        public string Fecha { get; set; }
        public string LoteSimplificado { get; set; }
        public double? DíaJuliano { get; set; }
        public string Weekday { get; set; }
        public string Week { get; set; }
        public double? DayNum { get; set; }
        public int Id { get; set; }

        public TrWeeks trweeks { get; set; }
    }
}
