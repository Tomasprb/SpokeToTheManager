namespace SpokeToTheManager.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        public double valor { get; set; }
        
        public bool acreditado{ get; set; }  
        public string observaciones { get; set; } = "";

        public string tipo {get;set;} = "";

        public DateTime? fecha { get; set; }

        
    }
}
