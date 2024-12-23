using Microsoft.EntityFrameworkCore;
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
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;
        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void BloquearUsuario(string IdUsuario)
        {
            var usuarioDesdebd= _db.ApplicationUsers.FirstOrDefault(u=>u.Id==IdUsuario);
            usuarioDesdebd.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string IdUsuario)
        {
            var usuarioDesdebd = _db.ApplicationUsers.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDesdebd.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
