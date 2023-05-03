using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable restore

namespace WebApplication2.Models
{
    public class BdIndicadoresPorLineaSLP
    {
        public BdEficaciaPorLinea BOSSAR { get; set; }
        public BdEficaciaPorLinea BSCHOCOLATE { get; set; }
        public BdEficaciaPorLinea BSCONFITADO { get; set; }
        public BdEficaciaPorLinea BUBULUBU { get; set; }
        public BdEficaciaPorLinea CAJETAGRANEL { get; set; }
        public BdEficaciaPorLinea CAJETAPET { get; set; }
        public BdEficaciaPorLinea CHICLOSO { get; set; }
        public BdEficaciaPorLinea GOMAS{ get; set; }
        public BdEficaciaPorLinea PALETAPAYASO { get; set; }
        public BdEficaciaPorLinea PALETONCOR { get; set; }
        public BdEficaciaPorLinea PECOSITA { get; set; }

        public BdCapacidadPorLinea CBOSSAR { get; set; }
        public BdCapacidadPorLinea CBSCHOCOLATE { get; set; }
        public BdCapacidadPorLinea CBSCONFITADO { get; set; }
        public BdCapacidadPorLinea CBUBULUBU { get; set; }
        public BdCapacidadPorLinea CCAJETAGRANEL { get; set; }
        public BdCapacidadPorLinea CCAJETAPET { get; set; }
        public BdCapacidadPorLinea CCHICLOSO { get; set; }
        public BdCapacidadPorLinea CGOMAS{ get; set; }
        public BdCapacidadPorLinea CPALETAPAYASO { get; set; }
        public BdCapacidadPorLinea CPALETONCOR { get; set; }
        public BdCapacidadPorLinea CPECOSITA { get; set; }

    }
}
