using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Sala
    {
        public Sala()
        {
            AsientosNavigation = new HashSet<Asiento>();
            Carteleras = new HashSet<Cartelera>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Sala")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdSala { get; set; }

        [Display(Name = "Número de Sala")]
        public int? NrSala { get; set; }

        [Display(Name = "Asientos")]
        public int? Asientos { get; set; }

        [ForeignKey("Cine")]
        [Display(Name = "Cine")]
        public int? IdCine { get; set; }

        [ForeignKey("Formato")]
        [Display(Name = "Formato")]
        public int? IdForma { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual Cine IdCineNavigation { get; set; }
        public virtual Formato IdFormaNavigation { get; set; }
        public virtual ICollection<Asiento> AsientosNavigation { get; set; }
        public virtual ICollection<Cartelera> Carteleras { get; set; }
    }
}
