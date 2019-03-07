using JDVusers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDVUsers.Models
{
    [Authorize]
    public class Telefono
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public TipoTelefono TipoTelefono { get; set; }
        [ Required]
        public string Numero { get; set; }

        public int? ContactoID { get; set; }

        public virtual Contacto Contacto { get; set; }

    }
}