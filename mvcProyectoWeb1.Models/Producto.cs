using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcProyectoWeb1.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<Transaccion> Transacciones { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
