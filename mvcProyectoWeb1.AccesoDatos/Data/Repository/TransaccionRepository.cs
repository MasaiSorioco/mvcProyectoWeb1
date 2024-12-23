using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Data;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository
{
    public class TransaccionRepository : Repository<Transaccion>, ITransaccionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransaccionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Transaccion transaccion)
        {
            var objDesdeDb = _db.Transacciones.FirstOrDefault(s => s.Id == transaccion.Id);
            objDesdeDb.Cantidad = transaccion.Cantidad;  // Asegúrate de que esta propiedad se llame 'Nombre' o 'NombreProducto', dependiendo de tu modelo
            objDesdeDb.Tipo = transaccion.Tipo;
            objDesdeDb.Fecha = transaccion.Fecha;

            _db.SaveChanges();
        }
    }
}
