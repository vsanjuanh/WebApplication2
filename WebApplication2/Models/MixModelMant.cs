using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication2.Models
{
    public class MixmodelMant
    {
        public BdMantenimientoCompletado BDMantenimientoCompletado { get; set; }
        public BdIpfm BDIpfm{ get; set; }
    }
}
