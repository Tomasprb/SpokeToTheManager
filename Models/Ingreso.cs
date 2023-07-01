using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Valor es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser un n�mero positivo mayor que cero.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo Valor debe ser num�rico.")]
        public double valor { get; set; }
       
        public bool acreditado{ get; set; }  
        [Required(ErrorMessage = "El campo obseracion es obligatorio.")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "El campo Tipo no puede contener n�meros.")]
        public string observaciones { get; set; } = "";
        [Required(ErrorMessage = "El campo Tipo es obligatorio.")]

        public string tipo {get;set;} = "";

        public DateTime? fecha { get; set; }

        
    }
}
