namespace API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User(string password, string name, string role)
        {
            Id = Guid.NewGuid();
            Password = password;
            Name = name;
            Role = role;
        }

        public User() { }
    }
}
