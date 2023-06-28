using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }= " ";
        [Required(ErrorMessage = "El campo email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }= " ";
        [Required(ErrorMessage = "El campo contraseñia es obligatorio.")]
        public string Contrasenia { get; set; } = " ";


    }
}
