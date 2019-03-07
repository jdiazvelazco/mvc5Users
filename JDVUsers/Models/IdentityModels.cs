using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JDVusers.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace JDVUsers.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        //[Key, Required]
        //public string UserName { get; set; }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
       // public string Email { get; set; }
        // [Required]
        //public string Contraseña { get; set; }
        public Boolean Activo { get; set; }
        [Required]
        public Rol Rol { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<JDVusers.Models.Contacto> Contactoes { get; set; }

        public System.Data.Entity.DbSet<JDVUsers.Models.Telefono> Telefonoes { get; set; }

        public System.Data.Entity.DbSet<JDVusers.Models.Direccion> Direccions { get; set; }
    }
}