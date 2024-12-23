using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        void Update(Proveedor proveedor);
    }
}
