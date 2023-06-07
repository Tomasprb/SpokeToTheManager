namespace SpokeToTheManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public User(string nombre, string email, string contrasenia)
        {
            this.Nombre = nombre;
            this.Email = email;
            this.Contrasenia = contrasenia;
        }

    }
}
