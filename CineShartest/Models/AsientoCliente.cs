using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class AsientoCliente
    {

        [Key]
        public int CodAcli { get; set; }

        [ForeignKey("Asiento")]
        [Display(Name = "Asiento")]
        public int? IdAsie { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        public int? IdCli { get; set; }

        public virtual Asiento IdAsieNavigation { get; set; }
        public virtual Cliente IdCliNavigation { get; set; }
    }
}
