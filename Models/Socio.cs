
using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Socio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }= " ";
        [Required(ErrorMessage = "El campo email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }= " ";
        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        public double Telefono { get; set; }
        [Required(ErrorMessage = "El campo tipo rubo es obligatorio.")]
        public int RubroId { get; set; }
        public Rubro Rubro { get; set; }

    }
}