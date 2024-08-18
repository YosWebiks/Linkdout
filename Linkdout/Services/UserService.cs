using Linkdout.Dal;
using Linkdout.Moodels;

namespace Linkdout.Services
{
    public class UserService
    {
        private DataLayer db;
        public UserService(DataLayer _db) { db = _db; }
        public async Task<UserModel> getUserById(int id)
        {
            return db.Users.Find(id);
        }
        public async Task<int> register(UserModel user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            UserModel created = db.Users.FirstOrDefault(u => u.userName == user.userName);
            return created.id;
        }
    }
}
