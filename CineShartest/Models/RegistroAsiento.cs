using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class RegistroAsiento
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Registro Asiento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdRst { get; set; }

        [ForeignKey("Venta")]
        [Display(Name = "Venta")]
        public int? IdVenta { get; set; }

        [ForeignKey("Cartelera")]
        [Display(Name = "Cartelera")]
        public int? IdCartelera { get; set; }

        [Display(Name = "Número de Asiento")]
        public int? NrRasiento { get; set; }

        public virtual Cartelera IdCarteleraNavigation { get; set; }
        public virtual Ventum IdVentaNavigation { get; set; }
    }
}
