using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Recurso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Nombre no puede contener números.")]
        public string nombre { get; set; } = " ";
        [Required(ErrorMessage = "El campo Tipo es obligatorio.")]
        public string tipo {get;set;}="";
        [Required(ErrorMessage = "El campo stock es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El Stock debe ser un número positivo y mayor que cero.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo Valor debe ser numérico.")]
        public float stock { get; set; }
        [Required(ErrorMessage = "El campo valor por unidad  es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor por unidad debe ser un número positivo y mayor que cero.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo Valor debe ser numérico.")]
        public float valor_unidad { get; set; } 
        [Required(ErrorMessage = "El campo Socio es obligatorio.")]
        public int SocioId { get; set; }
        public Socio? Socio { get; set; }
    }
}