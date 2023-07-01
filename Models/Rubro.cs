

using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Rubro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Nombre no puede contener números.")]
        public string Nombre { get; set; } = "";

        public ICollection<Socio> Socios { get; set; }
    }
}