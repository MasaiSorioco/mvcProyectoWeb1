using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Data;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _context;
        public ContenedorTrabajo(ApplicationDbContext context)
        {
            _context = context;
            //se agregan cada uno de los repositorios para que queden encapsulados
            Usuario = new UsuarioRepository(_context);
            Almacen = new AlmacenRepository(_context);
            Producto = new ProductoRepository(_context);
            Categoria = new CategoriaRepository(_context);
            Proveedor = new ProveedorRepository(_context);
            Transaccion = new TransaccionRepository(_context);
            Compra = new CompraRepository(_context);
            Slider = new SliderRepository(_context);
        }

        public ISliderRepository Slider { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }
        public IAlmacenRepository Almacen { get; private set; }
        public IProductoRepository Producto { get; private set; }
        public ICategoriaRepository Categoria { get; private set; }
        public IProveedorRepository Proveedor { get; private set; }
        public ITransaccionRepository Transaccion { get; private set; }
        public ICompraRepository Compra { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
