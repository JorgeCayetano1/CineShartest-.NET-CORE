using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class DetalleVentum
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Detalle de Venta")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdDventa { get; set; }

        [Display(Name = "Descripción")]
        public string DescripDventa { get; set; }

        [Display(Name = "Cantidad de Ventas")]
        public int? CantDventa { get; set; }

        [Display(Name = "Precio de Ventas")]
        public decimal? PrecioDventa { get; set; }

        [ForeignKey("Venta")]
        [Display(Name = "Venta")]
        public int? IdVenta { get; set; }

        public virtual Ventum IdVentaNavigation { get; set; }
    }
}
