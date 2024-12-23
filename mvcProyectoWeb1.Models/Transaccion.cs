using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcProyectoWeb1.Models
{
    public class Transaccion
    {
        [Key] public int Id { get; set; }
        public int ProductoId { get; set; }

        [Required]
        [Column(TypeName = "char(20)")]
        public string Tipo { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        // Relación con Producto
        public Producto Producto { get; set; }
    }
}
