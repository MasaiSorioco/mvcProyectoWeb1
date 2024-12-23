using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Data;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly ApplicationDbContext _db;
        public CompraRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Compra compra)
        {
            var objDesdeDb = _db.Compras.FirstOrDefault(s => s.Id == compra.Id);
            objDesdeDb.Cantidad = compra.Cantidad;  // Asegúrate de que esta propiedad se llame 'Nombre' o 'NombreProducto', dependiendo de tu modelo
            objDesdeDb.PrecioCompra = compra.PrecioCompra;
            objDesdeDb.FechaCompra = compra.FechaCompra;

            _db.SaveChanges();
        }
    }
}
