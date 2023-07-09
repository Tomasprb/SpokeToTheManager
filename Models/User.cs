using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Nombre no puede contener números.")]
        public string Nombre { get; set; }= " ";
        [Required(ErrorMessage = "El campo email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }= " ";
        [Required(ErrorMessage = "El campo contraseñia es obligatorio.")]
        public string Contrasenia { get; set; } = " ";

        public bool mantenerLoggeado { get; set; } = false;


    }
}
