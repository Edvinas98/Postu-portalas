using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostuPortalas.Core.Contracts;
using PostuPortalas.Core.Models;
using PostuPortalas.Core.Services;

namespace Postu_portalas.Pages
{
    public class PostsModel : PageModel
    {
        private readonly IPostService _postService;
        public List<Post> Posts = new List<Post>();
        public List<User> Users = new List<User>();

        public PostsModel(IPostService postService)
        {
            _postService = postService;
        }

        public async Task OnGet()
        {
            Posts = await _postService.GetAllPosts();
            Users = await _postService.GetAllUsers();
        }
    }
}
