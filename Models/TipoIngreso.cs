using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class TipoIngreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        public string descripcion { get; set; } = " ";
        
    }
}
