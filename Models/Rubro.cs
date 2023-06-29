

using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Rubro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; } = "";

        public ICollection<Socio> Socios { get; set; }
    }
}