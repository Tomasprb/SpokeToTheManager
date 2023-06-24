using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        [Display(Name = "valor", ErrorMenssage = "Ingrese un valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser un n�mero positivo mayor que cero.")]
        public double valor { get; set; }
        public bool acreditado{ get; set; }  
        public string observaciones { get; set; } = "";

        public string tipo {get;set;} = "";

        public DateTime? fecha { get; set; }

        
    }
}
