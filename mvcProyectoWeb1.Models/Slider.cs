using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb1.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para el slider")]

        public string NombreSlider { get; set; }
        [Required]
        public bool Estado { get; set;}
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]

        public string UrlImagen { get; set; }
    }
}
