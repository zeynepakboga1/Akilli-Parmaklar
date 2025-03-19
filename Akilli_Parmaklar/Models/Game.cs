namespace Akilli_Parmaklar.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ExecutablePath { get; set; }
        public int LikeCount { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
