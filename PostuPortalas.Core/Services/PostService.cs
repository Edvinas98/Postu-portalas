using PostuPortalas.Core.Models;
using PostuPortalas.Core.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PostuPortalas.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostDbRepository _postRepository;

        public PostService(IPostDbRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<Post> AddPost(Post post)
        {
            return await _postRepository.AddPost(post);
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postRepository.GetPostById(id);
        }

        public async Task UpdatePost(Post post)
        {
            await _postRepository.UpdatePost(post);
        }

        public async Task DeletePost(Post post)
        {
            await _postRepository.DeletePost(post);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _postRepository.GetAllUsers();
        }

        public async Task<User> AddUser(User user)
        {
            user.Email = user.Email.ToLower();

            if (await _postRepository.CheckNewUser(user))
                return user;

            return await _postRepository.AddUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _postRepository.GetUserById(id);
        }

        public async Task UpdateUser(User user)
        {
            await _postRepository.UpdateUser(user);
        }

        public async Task DeleteUser(User user)
        {
            await _postRepository.DeleteUser(user);
        }
    }
}
