using JDVUsers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JDVusers.Models
{
   
    public class Contacto
    {

        public Contacto()
        {
            Direcciones = new List<Direccion>();
            Telefonos = new List<Telefono>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ Required]
        public string Nombre { get; set; }
        [Required]
        public TipoContacto TipoContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string RFC { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }
        public virtual ICollection<Telefono> Telefonos { get; set; }
    }



}