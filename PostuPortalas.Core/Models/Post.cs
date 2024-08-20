using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostuPortalas.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User TheUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }

        public Post()
        {
            Id = 0;
            TheUser = new User();
            Title = string.Empty;
            Content = string.Empty;
            TimeStamp = DateTime.Now;
        }

        public Post(int id, User user, string title, string content)
        {
            Id = id;
            TheUser = user;
            Title = title;
            Content = content;
            TimeStamp = DateTime.Now;
        }
    }
}
