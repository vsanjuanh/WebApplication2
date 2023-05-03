using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class TrDate
    {
        public string Fecha { get; set; }
        public string LoteSimplificado { get; set; }
        public double? DíaJuliano { get; set; }
        public string Weekday { get; set; }
        public string Week { get; set; }
        public double? DayNum { get; set; }
        public string F7 { get; set; }
        public string F8 { get; set; }
    }
}
