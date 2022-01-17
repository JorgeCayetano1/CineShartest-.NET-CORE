using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Cartelera
    {
        public Cartelera()
        {
            RegistroAsientos = new HashSet<RegistroAsiento>();
            Venta = new HashSet<Ventum>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Cartelera")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdCartelera { get; set; }

        [ForeignKey("Pelicula")]
        [Display(Name = "Pelicula")]
        [Required(ErrorMessage = "La Pelicula es OBLIGATORIA")]
        public int? IdPeli { get; set; }

        [ForeignKey("Sala")]
        [Display(Name = "Sala")]
        [Required(ErrorMessage = "La Sala es OBLIGATORIA")]
        public int? IdSala { get; set; }

        [Display(Name = "Empieza")]
        [Required(ErrorMessage = "La Hora de Inicio es OBLIGATORIA")]
        public TimeSpan? HoraIni { get; set; }

        [Display(Name = "Termina")]
        [Required(ErrorMessage = "La Hora de Fin es OBLIGATORIA")]
        public TimeSpan? HoraFin { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La Fecha es OBLIGATORIA")]
        public DateTime? Fecha { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es OBLIGATORIO")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual Pelicula IdPeliNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<RegistroAsiento> RegistroAsientos { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
