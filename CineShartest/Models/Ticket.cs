using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    public partial class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ID Ticket")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string IdTicket { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El tipo es OBLIGATORIO")]
        public string Tipo { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción es OBLIGATORIA")]
        public string DescripTicket { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es OBLIGATORIO")]
        public decimal? PrecioTicket { get; set; }

        [ForeignKey("Estado")]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es OBLIGATORIO")]
        public int? CodEst { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
    }
}
