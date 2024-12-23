using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcProyectoWeb1.Data;
using mvcProyectoWeb1.Models;
using mvcProyectoWeb1.Utilidades;

namespace mvcProyectoWeb1.AccesoDatos.Inicializador
{
    public class InicializadorBD : IInicializadorBD
    {
        private readonly ApplicationDbContext _bd;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public InicializadorBD(ApplicationDbContext bd,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _bd = bd;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Inicializar() 
        {
            try 
            {
                if(_bd.Database.GetPendingMigrations().Count() > 0) 
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception ex) 
            {

            }
            if(_bd.Roles.Any(ro=>ro.Name == CNT.Administrador)) return;

            //creacion de roles
            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Registrado)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();

            // creacion del usuario inicial
            _userManager.CreateAsync(new ApplicationUser 
            {
                UserName = "",
                Email = "",
                EmailConfirmed = true,
                Nombre = "",
            }, "").GetAwaiter().GetResult();
        }
    }
}
