using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Dulceria = new HashSet<Dulcerium>();
            Venta = new HashSet<Ventum>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Empleado")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdEmp { get; set; }

        [Display(Name = "Nombres")]
        public string NomEmp { get; set; }

        [Display(Name = "Apellidos")]
        public string ApeEmp { get; set; }

        [Display(Name = "Cargo")]
        public string CargEmp { get; set; }

        [Display(Name = "Sueldo")]
        public decimal? SuelEmp { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual ICollection<Dulcerium> Dulceria { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
