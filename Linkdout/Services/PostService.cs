using Linkdout.Dal;
using Linkdout.DTO;
using Linkdout.Moodels;
using Microsoft.EntityFrameworkCore;

namespace Linkdout.Services
{
    public class PostService
    {
        private DataLayer db;
        public PostService(DataLayer _db) { db = _db; }
        public async Task<PostListDTO> getAll()
        {
            return db.Posts.Include(p => p.user).ToList() as PostListDTO;
        }

        public async Task<PostModel> getPostById(int id)
        {
            return db.Posts.Include(p => p.user).FirstOrDefault(p => p.id == id);
        }
        public async Task<bool> addNewPost(NewPostDTO req)
        {
            try
            {
                UserModel user = db.Users.Find(req.userId);
                req.Post.user = user;
                db.Posts.Add(req.Post);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
