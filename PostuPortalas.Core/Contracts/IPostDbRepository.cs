using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostuPortalas.Core.Models;
using PostuPortalas.Core.Repositories;

namespace PostuPortalas.Core.Contracts
{
    public interface IPostDbRepository
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> AddPost(Post post);
        Task<Post> GetPostById(int id);
        Task UpdatePost(Post post);
        Task DeletePost(Post post);
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<bool> CheckNewUser(User user);
        Task<User> GetUserById(int id);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
