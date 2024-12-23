using mvcProyectoWeb1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository
{
    public interface ISliderRepository:IRepository<Slider>
    {
        void Update(Slider slider);
    }
}
