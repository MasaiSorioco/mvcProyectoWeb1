using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository
{
    public interface IProductoRepository :IRepository<Producto>
    {
        void Update(Producto producto);
        IQueryable<Producto> AsQueryable();

    }
}
