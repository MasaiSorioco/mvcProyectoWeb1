using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace mvcProyectoWeb1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="Ingrese su nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese su Departamento")]
        public string Departamento { get; set; }
        [Required(ErrorMessage = "Ingrese su Celular")]
        public string Celular { get; set;}
    }
}
