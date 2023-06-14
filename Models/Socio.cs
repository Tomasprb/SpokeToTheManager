
namespace SpokeToTheManager.Models
{
    public class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }= " ";
        public string Email { get; set; }= " ";
        public double Telefono { get; set; }
        public int RubroId { get; set; }
        public Rubro rubro { get; set; }

    }
}