using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository
{
    public interface IUsuarioRepository: IRepository<ApplicationUser>
    {
        void BloquearUsuario(String IdUsuario);

        void DesbloquearUsuario(String IdUsuario);

    }
}
