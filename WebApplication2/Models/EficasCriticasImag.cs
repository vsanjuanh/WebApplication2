using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class EficasCriticasImag
    {
        public int Id { get; set; }
        public string ImgaeUrl { get; set; }
        public int? EficaciasCriticasId { get; set; }

        public virtual EficasCritica EficaciasCriticas { get; set; }
    }
}
