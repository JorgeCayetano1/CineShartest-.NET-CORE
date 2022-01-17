using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineShartest.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        [Key]
        public int CodGene { get; set; }

        [Display(Name = "Genero")]
        public string NomGene { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
