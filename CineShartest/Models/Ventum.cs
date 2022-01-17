using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            RegistroAsientos = new HashSet<RegistroAsiento>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Venta")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdVenta { get; set; }

        [ForeignKey("Empleado")]
        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "El Empleado es OBLIGATORIO")]
        public int? IdEmp { get; set; }

        [Display(Name = "Fecha venta")]
        [Required(ErrorMessage = "La Fecha es OBLIGATORIA")]
        public DateTime? FechaVent { get; set; }

        [Display(Name = "Compra de Asientos")]
        [Required(ErrorMessage = "El Asiento Vendido es OBLIGATORIO")]
        public int? AsieVent { get; set; }

        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "El Tipo de Pago es OBLIGATORIO")]
        public string TpagoVent { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "El Cliente es OBLIGATORIO")]
        public int? IdCli { get; set; }

        [ForeignKey("Cartelera")]
        [Display(Name = "Cartelera")]
        [Required(ErrorMessage = "La Cartelera es OBLIGATORIA")]
        public int? IdCartelera { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es OBLIGATORIO")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual Cartelera IdCarteleraNavigation { get; set; }
        public virtual Cliente IdCliNavigation { get; set; }
        public virtual Empleado IdEmpNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<RegistroAsiento> RegistroAsientos { get; set; }
    }
}
