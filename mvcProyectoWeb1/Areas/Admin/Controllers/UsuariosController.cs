using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace mvcProyectoWeb1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
        [HttpGet]
        public IActionResult Bloquear(string id) 
        { 
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return View("Index",_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
        [HttpGet]
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            return View("Index", _contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
    }
}
