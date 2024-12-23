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
    public class SliderRepository:Repository<Slider>,ISliderRepository
    {
        private readonly ApplicationDbContext _db;
        public SliderRepository(ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }
        public void Update(Slider slider)
        {
            var objDesdeDb= _db.Sliders.FirstOrDefault(s=>s.Id==slider.Id);
            objDesdeDb.NombreSlider= slider.NombreSlider;
            objDesdeDb.Estado = slider.Estado;
            objDesdeDb.UrlImagen = slider.UrlImagen;
        }
    }
}
