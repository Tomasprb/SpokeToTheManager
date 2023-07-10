using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Valor es obligatorio.")]
        [RegularExpression(@"^[^a-zA-Z]+$", ErrorMessage = "El campo Valor no puede contener letras.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser un número positivo mayor que cero.")]
        public double valor { get; set; }
       
        public bool acreditado{ get; set; }  
        [Required(ErrorMessage = "El campo obseracion es obligatorio.")]
       
        public string observaciones { get; set; } = "";
        [Required(ErrorMessage = "El campo Tipo es obligatorio.")]

        public string tipo {get;set;} = "";

        public DateTime? fecha { get; set; }

        
    }
}
