using System.ComponentModel.DataAnnotations;

namespace mvcProyectoWeb1.Models
{
    public class Proveedor
    {
        [Key] public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        // Relación con Compras
        public ICollection<Compra> Compras { get; set; }
    }
}
