using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CompraController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CompraController(IContenedorTrabajo contenedorTrabajo)
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
            ViewBag.Producto = new SelectList(_contenedorTrabajo.Producto.GetAll(), "Id", "Nombre");
            ViewBag.Proveedor = new SelectList(_contenedorTrabajo.Proveedor.GetAll(), "Id", "Nombre");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Compra compra)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Compra.Add(compra);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Producto = new SelectList(_contenedorTrabajo.Producto.GetAll(), "Id", "Nombre");
            ViewBag.Proveedor = new SelectList(_contenedorTrabajo.Proveedor.GetAll(), "Id", "Nombre");
            return View(compra);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Compra compra = new Compra();
            compra = _contenedorTrabajo.Compra.Get(id);
            if (compra == null)
            {
                return NotFound();

            }
            ViewBag.Producto = new SelectList(_contenedorTrabajo.Producto.GetAll(), "Id", "Nombre");
            ViewBag.Proveedor = new SelectList(_contenedorTrabajo.Proveedor.GetAll(), "Id", "Nombre");
            return View(compra);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Compra compra)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Compra.Update(compra);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Producto = new SelectList(_contenedorTrabajo.Producto.GetAll(), "Id", "Nombre");
            ViewBag.Proveedor = new SelectList(_contenedorTrabajo.Proveedor.GetAll(), "Id", "Nombre");
            return View(compra);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Compra.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Compra.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Compra" });
            }
            _contenedorTrabajo.Compra.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la compra" });
        }
        #endregion
    }
}
