using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class TipoEgreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Descripcion no puede contener n�meros.")]
        public string descripcion { get; set; } = " ";
    }
}
