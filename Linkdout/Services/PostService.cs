using Linkdout.Dal;
using Linkdout.DTO;
using Linkdout.Moodels;

namespace Linkdout.Services
{
    public class PostService
    {
        private DataLayer db;
        public PostService(DataLayer _db) { db = _db; }
        public async Task<PostListDTO> getAll()
        {
            return db.Posts.ToList() as PostListDTO;
        }

        public async Task<PostModel> getPostById(int id)
        {
            return db.Posts.Find(id);
        }
    }
}
