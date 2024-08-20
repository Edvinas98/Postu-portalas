using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostuPortalas.Core.Models;
using PostuPortalas.Core.Contracts;

namespace PostuPortalas.Core.Repositories
{
    public class PostDbRepository : IPostDbRepository
    {
        public async Task<List<Post>> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            using (var context = new MyDbContext())
            {
                posts = await context.Posts.Include(i => i.TheUser).ToListAsync();
            }
            return posts;
        }

        public async Task<Post> AddPost(Post post)
        {
            using (var context = new MyDbContext())
            {
                post.TheUser = context.Users.Where(x => x.Id == post.TheUser.Id).First();
                await context.Posts.AddAsync(post);
                context.SaveChanges();
            }
            return post;
        }

        public Task<Post> GetPostById(int id)
        {
            Post post = new Post();
            using (var context = new MyDbContext())
            {
                post = context.Posts.Include(i => i.TheUser).Where(x => x.Id == id).First();
            }
            return Task.FromResult(post);
        }

        public Task UpdatePost(Post post)
        {
            using (var context = new MyDbContext())
            {
                context.Posts.Update(post);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task DeletePost(Post post)
        {
            using (var context = new MyDbContext())
            {
                context.Posts.Remove(post);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var context = new MyDbContext())
            {
                users = await context.Users.ToListAsync();
            }
            return users;
        }

        public async Task<User> AddUser(User user)
        {
            using (var context = new MyDbContext())
            {
                await context.Users.AddAsync(user);
                context.SaveChanges();
            }
            return user;
        }

        public Task<bool> CheckNewUser(User user)
        {
            List<User> users = new List<User>();
            using (var context = new MyDbContext())
            {
                users = context.Users.Where(x => x.Name == user.Name && x.Email == user.Email).ToList();
            }
            return Task.FromResult(users.ToList().Count > 0);
        }

        public Task<User> GetUserById(int id)
        {
            User user = new User();
            using (var context = new MyDbContext())
            {
                user = context.Users.Where(x => x.Id == id).First();
            }
            return Task.FromResult(user);
        }

        public Task UpdateUser(User user)
        {
            using (var context = new MyDbContext())
            {
                context.Users.Update(user);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task DeleteUser(User user)
        {
            using (var context = new MyDbContext())
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
