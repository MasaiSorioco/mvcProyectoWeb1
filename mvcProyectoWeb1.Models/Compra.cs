using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcProyectoWeb1.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioCompra { get; set; }
        public DateTime FechaCompra { get; set; }

        // Relaciones
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
    }
}
