using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Dulcerium
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Dulceria")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdDulc { get; set; }

        [Display(Name = "Dulceria")]
        public string NomDulc { get; set; }

        [ForeignKey("Encargado")]
        [Display(Name = "Encargado")]
        public int? IdEmp { get; set; }

        [ForeignKey("Cine")]
        [Display(Name = "Cine")]
        public int? IdCine { get; set; }
        
        [ForeignKey("Productos")]
        [Display(Name = "Productos")]
        public int? IdProd { get; set; }

        public virtual Cine IdCineNavigation { get; set; }
        public virtual Empleado IdEmpNavigation { get; set; }
        public virtual Producto IdProdNavigation { get; set; }
    }
}
