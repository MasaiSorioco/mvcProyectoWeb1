using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcProyectoWeb1.Models.ViewModels
{
    public class ProductoVM
    {
        public Producto Producto { get; set; }

        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
