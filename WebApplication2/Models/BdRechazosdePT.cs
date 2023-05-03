using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace WebApplication2.Models
{
    public partial class BdRechazosdePT
    {
        [ForeignKey("Id")]
        public string Region { get; set; }

    }
}
