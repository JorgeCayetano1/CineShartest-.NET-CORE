using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Carteleras = new HashSet<Cartelera>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Pelicula")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdPeli { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "El Titulo es OBLIGATORIO")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción es OBLIGATORIA")]
        public string DescripPeli { get; set; }

        [Display(Name = "Duración")]
        [Required(ErrorMessage = "La Duración es OBLIGATORIA")]
        public TimeSpan? DurPeli { get; set; }

        [ForeignKey("Genero")]
        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El Genero es OBLIGATORIO")]
        public int? CodGene { get; set; }

        [Display(Name = "Clasificación")]
        [Required(ErrorMessage = "La Clasificación es OBLIGATORIA")]
        public string ClasifPeli { get; set; }

        [Display(Name = "Portada")]
        [Required(ErrorMessage = "La Portada es OBLIGATORIA")]
        public string Portada { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es OBLIGATORIO")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual Genero CodGeneNavigation { get; set; }
        public virtual ICollection<Cartelera> Carteleras { get; set; }
    }
}
