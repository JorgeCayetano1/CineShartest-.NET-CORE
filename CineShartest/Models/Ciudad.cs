using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineShartest.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Cines = new HashSet<Cine>();
        }

        [Key]
        public int CodCiudad { get; set; }

        [Display(Name = "Ciudad")]
        public string NomCiudad { get; set; }

        public virtual ICollection<Cine> Cines { get; set; }
    }
}
