using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class EficasCritica
    {
        public EficasCritica()
        {
            EficasCriticasImag = new HashSet<EficasCriticasImag>();
        }

        public int Id { get; set; }
        public int Myproperty { get; set; }

        public virtual ICollection<EficasCriticasImag> EficasCriticasImag { get; set; }
    }
}
