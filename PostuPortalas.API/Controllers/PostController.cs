using Microsoft.AspNetCore.Mvc;
using PostuPortalas.Core.Contracts;
using PostuPortalas.Core.Models;
using PostuPortalas.Core.Services;

namespace PostuPortalas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                List<Post> posts = await _postService.GetAllPosts();
                if (posts.Count == 0)
                    return NotFound();
                return Ok(posts);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("GetPostById")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            try
            {
                Post post = await _postService.GetPostById(postId);
                if (post.Id == 0)
                    return NotFound();

                return Ok(post);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost(int userID, string title, string content)
        {
            try
            {
                User user = await _postService.GetUserById(userID);
                if(user.Id == 0 )
                    return NotFound();

                Post post = new Post(0, user, title, content);
                return Ok(await _postService.AddPost(post));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("AddPostJSON")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> AddPostJSON(Post post)
        {
            try
            {
                User user = await _postService.GetUserById(post.Id);
                if (user.Id == 0)
                    return NotFound();
                post.TheUser = user;
                post.Id = 0;
                post = await _postService.AddPost(post);
                return Ok(post);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPatch("UpdatePost")]
        public async Task<IActionResult> UpdatePost(int postID, int userID, string name, string email)
        {
            try
            {
                Post post = await _postService.GetPostById(postID);
                if (post.Id == 0)
                    return NotFound();

                await _postService.UpdatePost(post);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPatch("UpdatePostJSON")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdatePostJSON(Post post)
        {
            try
            {
                Post tempPost = await _postService.GetPostById(post.Id);
                if (tempPost.Id == 0)
                    return NotFound();
                post.TheUser = tempPost.TheUser;
                await _postService.UpdatePost(post);
                return Ok(post);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(int postID)
        {
            try
            {
                Post post = await _postService.GetPostById(postID);
                if (post.Id == 0)
                    return NotFound();

                await _postService.DeletePost(post);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeletePostJSON")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> DeletePostJSON(Post post)
        {
            try
            {
                await _postService.DeletePost(post);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await _postService.GetAllUsers();
                if (users.Count == 0)
                    return NotFound();
                return Ok(users);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                User user = await _postService.GetUserById(userId);
                if (user.Id == 0)
                    return NotFound();

                return Ok(user);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(string name, string email)
        {
            try
            {
                User user = await _postService.AddUser(new User(0, name, email));
                return Ok(user);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("AddUserJSON")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> AddUserJSON(User user)
        {
            try
            {
                user = await _postService.AddUser(user);
                return Ok(user);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int userID, string name, string email)
        {
            try
            {
                User user = await _postService.GetUserById(userID);
                if (user.Id == 0)
                    return NotFound();

                await _postService.UpdateUser(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPatch("UpdateUserJSON")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdateUserJSON(User user)
        {
            try
            {
                await _postService.UpdateUser(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userID)
        {
            try
            {
                User user = await _postService.GetUserById(userID);
                if (user.Id == 0)
                    return NotFound();

                await _postService.DeleteUser(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteUserJSON")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> DeleteUserJSON(User user)
        {
            try
            {
                await _postService.DeleteUser(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
