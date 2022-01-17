using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Dulceria = new HashSet<Dulcerium>();
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Producto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdProd { get; set; }

        [Display(Name = "Producto")]
        public string NomProd { get; set; }

        [Display(Name = "Precio")]
        public decimal? PrecioProd { get; set; }

        [Display(Name = "Cantidad")]
        public int? CantProd { get; set; }

        public virtual ICollection<Dulcerium> Dulceria { get; set; }
    }
}
