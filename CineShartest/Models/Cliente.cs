using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            AsientoClientes = new HashSet<AsientoCliente>();
            Venta = new HashSet<Ventum>();
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "ID Cliente")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ID_CLI { get; set; }

        [Required(ErrorMessage = "Los Nombres son OBLIGATORIOS")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombres")]
        public string NOM_CLI { get; set; }

        [Required(ErrorMessage = "Los Apellidos son OBLIGATORIOS")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        public string APE_CLI { get; set; }

        [Required(ErrorMessage = "El DNI es OBLIGATORIO")]
        [Display(Name = "DNI")]
        public string DNI { get; set; }


        public virtual ICollection<AsientoCliente> AsientoClientes { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
