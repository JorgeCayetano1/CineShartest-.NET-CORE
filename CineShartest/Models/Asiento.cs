using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Asiento
    {
        public Asiento()
        {
            AsientoClientes = new HashSet<AsientoCliente>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Asiento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdAsie { get; set; }

        [Display(Name = "Número Asiento")]
        [Required(ErrorMessage = "El Número de asiento es OBLIGATORIO")]
        public int? NrAsie { get; set; }

        [ForeignKey("Sala")]
        [Display(Name = "Sala")]
        [Required(ErrorMessage = "La Sala es OBLIGATORIA")]
        public int? IdSala { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es OBLIGATORO")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<AsientoCliente> AsientoClientes { get; set; }
    }
}
