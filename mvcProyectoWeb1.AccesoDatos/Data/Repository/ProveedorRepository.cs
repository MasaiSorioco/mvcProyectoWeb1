using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Data;
using mvcProyectoWeb1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        private readonly ApplicationDbContext _db;
        public ProveedorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Proveedor proveedor)
        {
            var objDesdeDb = _db.Proveedores.FirstOrDefault(s => s.Id == proveedor.Id);
            objDesdeDb.Nombre = proveedor.Nombre;  // Asegúrate de que esta propiedad se llame 'Nombre' o 'NombreProducto', dependiendo de tu modelo
            objDesdeDb.Direccion = proveedor.Direccion;
            objDesdeDb.Telefono = proveedor.Telefono;

            _db.SaveChanges();
        }
    }
}
