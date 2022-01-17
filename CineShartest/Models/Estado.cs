using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineShartest.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Asientos = new HashSet<Asiento>();
            Carteleras = new HashSet<Cartelera>();
            Empleados = new HashSet<Empleado>();
            Peliculas = new HashSet<Pelicula>();
            Salas = new HashSet<Sala>();
            Tickets = new HashSet<Ticket>();
            Venta = new HashSet<Ventum>();
        }
        [Key]
        public int CodEst { get; set; }

        [Display(Name = "Estado")]
        public string DescripEst { get; set; }

        public virtual ICollection<Asiento> Asientos { get; set; }
        public virtual ICollection<Cartelera> Carteleras { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Pelicula> Peliculas { get; set; }
        public virtual ICollection<Sala> Salas { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
