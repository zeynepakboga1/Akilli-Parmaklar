namespace Akilli_Parmaklar.Models
{
    public class Game
    {
        public Guid Id { get; set; } // 1
        public string Name { get; set; } // test
        public string Description { get; set; } // test desc
        public string ImagePath { get; set; }
        public string ExecutablePath { get; set; }
        public int LikeCount { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
