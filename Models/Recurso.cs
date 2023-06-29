using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Recurso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string nombre { get; set; } = " ";
        [Required(ErrorMessage = "El campo Tipo es obligatorio.")]
        public string tipo {get;set;}="";
        [Required(ErrorMessage = "El campo stock es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El Stock debe ser un número positivo y mayor que cero.")]
        public float stock { get; set; }
        [Required(ErrorMessage = "El campo valor por unidad  es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor por unidad debe ser un número positivo y mayor que cero.")]
        public float valor_unidad { get; set; } 

    }
}