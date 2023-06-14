

namespace SpokeToTheManager.Models
{
    public class Rubro
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = "";

        public ICollection<Socio> Socios { get; set; }
    }
}