using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class AlmacenesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public AlmacenesController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Almacen.Add(almacen);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(almacen);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Almacen almacen = new Almacen();
            almacen = _contenedorTrabajo.Almacen.Get(id);
            if (almacen == null)
            {
                return NotFound();

            }
            return View(almacen);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Almacen almacen)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Almacen.Update(almacen);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(almacen);
        }
        
    }
}
