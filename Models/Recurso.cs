namespace SpokeToTheManager.Models
{
    public class Recurso
    {
        public int Id { get; set; }
        public string nombre { get; set; } = " ";

        public string tipo {get;set;}="";
        public float stock { get; set; }  
        public float valor_unidad { get; set; } 

    }
}