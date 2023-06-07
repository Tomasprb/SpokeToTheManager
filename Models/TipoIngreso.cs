namespace SpokeToTheManager.Models
{
    public class TipoIngreso
    {
        public int Id { get; set; }
        public string descripcion { get; set; } 
        public TipoIngreso(string descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
