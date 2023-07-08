
using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Socio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Nombre no puede contener n�meros.")]
        public string Nombre { get; set; }= " ";
        [Required(ErrorMessage = "El campo email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una direcci�n de correo electr�nico v�lida.")]
        public string Email { get; set; }= " ";
        [Required(ErrorMessage = "El campo Tel�fono es obligatorio.")]
        public double Telefono { get; set; }
        [Required(ErrorMessage = "El campo tipo rubo es obligatorio.")]
        public int RubroId { get; set; }
        public Rubro? Rubro { get; set; }

        public ICollection<Recurso>? Recursos { get; set; }

    }
}