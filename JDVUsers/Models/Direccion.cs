using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDVusers.Models
{
    [Authorize]
    public class Direccion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public TipoDireccion TipoDireccion { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string CodigoPostal { get; set; }

        public int? ContactoID { get; set; }


        public virtual Contacto Contacto { get; set; }

    }
}