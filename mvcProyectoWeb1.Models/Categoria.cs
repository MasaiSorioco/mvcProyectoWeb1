using System.ComponentModel.DataAnnotations;

namespace mvcProyectoWeb1.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(255, ErrorMessage = "La longitud máxima para el campo Nombre es de 255 caracteres.")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relación con Productos
        public ICollection<Producto> Productos { get; set; }

        // Constructor para inicializar la colección de Productos
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }
    }
}

