using System.ComponentModel.DataAnnotations;

namespace SpokeToTheManager.Models
{
    public class Egreso
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser un número positivo mayor que cero.")]
        public double valor { get; set; }
        
        public bool acreditado{ get; set; }  
        public string observaciones { get; set; }= "";
        public string tipo { get; set; }= "";
        public DateTime? fecha { get; set; }

    }
}
