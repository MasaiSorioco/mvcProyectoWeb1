using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProveedorController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProveedorController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Proveedor.Add(proveedor);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Proveedor proveedor = new Proveedor();
            proveedor = _contenedorTrabajo.Proveedor.Get(id);
            if (proveedor == null)
            {
                return NotFound();

            }
            return View(proveedor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Proveedor proveedor)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Proveedor.Update(proveedor);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Proveedor.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Proveedor.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando proveedor" });
            }
            _contenedorTrabajo.Proveedor.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la proveedor" });
        }
        #endregion
    }
}
