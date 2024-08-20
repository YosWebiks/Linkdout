using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Linkdout.Moodels
{
    public class UserModel
    {
        public int id { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
    }

}