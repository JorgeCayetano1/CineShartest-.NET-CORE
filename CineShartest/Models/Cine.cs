using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Cine
    {
        public Cine()
        {
            Dulceria = new HashSet<Dulcerium>();
            Salas = new HashSet<Sala>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Cine")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdCine { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "El Empleado es OBLIGATORIO")]
        public string NomEmp { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La Dirección es OBLIGATORIA")]
        public string DirCine { get; set; }

        [ForeignKey("Ciudad")]
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "La Cuidad es OBLIGATORIA")]
        public int? CodCiudad { get; set; }

        public virtual Ciudad CodCiudadNavigation { get; set; }
        public virtual ICollection<Dulcerium> Dulceria { get; set; }
        public virtual ICollection<Sala> Salas { get; set; }
    }
}
