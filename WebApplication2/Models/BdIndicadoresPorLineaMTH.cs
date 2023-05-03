using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable restore

namespace WebApplication2.Models
{
    public class BdIndicadoresPorLineaMTH
    {
        public BdEficaciaPorLinea MACARRON { get; set; }
        public BdEficaciaPorLinea OBLEAKAULITZ1 { get; set; }
        public BdEficaciaPorLinea OBLEAKAULITZ3 { get; set; }
        public BdEficaciaPorLinea PALETA { get; set; }
        public BdCapacidadPorLinea CMACARRON { get; set; }
        public BdCapacidadPorLinea COBLEAKAULITZ1 { get; set; }
        public BdCapacidadPorLinea COBLEAKAULITZ3 { get; set; }
        public BdCapacidadPorLinea CPALETA { get; set; }

    }
}
