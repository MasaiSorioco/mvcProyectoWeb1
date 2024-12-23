using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Data;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public IQueryable<Producto> AsQueryable()
        {
            return _db.Set<Producto>().AsQueryable();
        }
        public void Update(Producto producto)
        {
            var objDesdeDb = _db.Productos.FirstOrDefault(s => s.Id == producto.Id);
                objDesdeDb.Nombre = producto.Nombre;  // Asegúrate de que esta propiedad se llame 'Nombre' o 'NombreProducto', dependiendo de tu modelo
                objDesdeDb.Descripcion = producto.Descripcion;
                objDesdeDb.Precio = producto.Precio;
                objDesdeDb.Stock = producto.Stock;
                objDesdeDb.UrlImagen = producto.UrlImagen;

            _db.SaveChanges();
        }
    }
}
