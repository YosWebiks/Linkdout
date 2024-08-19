namespace Linkdout.Moodels
{
    public class PostModel
    {
        public int id { get; set; }
        public string body { get; set; }
        public UserModel? user { get; set; }
        public int likes { get; set; }

    }
}
