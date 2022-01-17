using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CineShartest.Models
{
    [Table("Usuario", Schema = "dbo")]
    public partial class Usuario
    {
        [Key]
        public int CodSu { get; set; }
        [Display(Name ="Nick de Usuario")]
        public string SuNick { get; set; }
        [Display(Name = "Email de Usuario")]
        public string SuEmail { get; set; }
        [Display(Name = "Contraseña de Usuario")]
        [DataType(DataType.Password)]
        public string SuPass { get; set; }
        [Display(Name = "Estado de Usuario")]
        public bool SuEst { get; set; }
    }
}
