using System.ComponentModel.DataAnnotations;

namespace PostuPortalas.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public User(int id)
        {
            Id = id;
            Name = string.Empty;
            Email = string.Empty;
        }

        public User()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
        }
    }
}
