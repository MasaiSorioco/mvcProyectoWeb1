using Microsoft.AspNetCore.Mvc.Rendering;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);
        IEnumerable<SelectListItem> GetListaCategorias();
    }
}
