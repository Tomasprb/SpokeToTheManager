using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class TipoIngreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Descripcion no puede contener números.")]
        public string descripcion { get; set; } = " ";
        
    }
}
