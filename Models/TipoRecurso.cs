

using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class TipoRecurso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        public string descripcion { get; set; } = " ";
    }
}