using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Formato
    {
        public Formato()
        {
            Salas = new HashSet<Sala>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Formato")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdForma { get; set; }

        [Display(Name = "Formato")]
        public string NomForma { get; set; }

        [Display(Name = "Descripción")]
        public string DescripForma { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }
    }
}
