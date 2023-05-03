using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication2.Models
{
    public class Mixmodel
    {
        [Required(ErrorMessage = "Name is required.")]
        public BdAccidentes BDAccidente { get; set; }
        public BdBajasPt BDBajasPt { get; set; }
        public BdTiempoExtra BdTiempoExtras { get; set; }
        public BdBarredura BDBarredura { get; set; }
        public BdCapUtilizada BdCapUtilizada { get; set; }
        public BdCuadroBásico BDCuadroBásico { get; set; }
        public BdDesperdiciosEmpaque BdDesperdiciosEmpaque { get; set; }
        public BdDesperdiciosTotales BdDesperdiciosTotale { get; set; }
        public BdEficaciaPorLinea BdEficaciaPorLineas { get; set; }
        public BdEficacia BdEficaci { get; set; }
        public BdEficiencia BdEficiencia { get; set; }
        public BdMantenimientoCompletado BdMantenimientoCompletados { get; set; }
        public BdPesoProducidoPesoPagado BdPesoProducidoPesoPagado { get; set; }
        public BdProductividadLaboral BdProductividadLaboral { get; set; }
        public BdQuejasA BdQuejasAs { get; set; }
        public BdQuejasB BdQuejasBs { get; set; }
        public BdQuejasC BdQuejasCs { get; set; }
        public BdQuejasTotales BdQuejasTotales { get; set; }
        public BdToneladasProducidas BdToneladasProducida { get; set; }
        public BdVariaciónDeLaOrden BdVariaciónDeLaOrden { get; set; }
        public BdValorDeLaProducción BdValorDeLaProducción { get; set; }
        public Edit edit { get; set; }
    }
}
