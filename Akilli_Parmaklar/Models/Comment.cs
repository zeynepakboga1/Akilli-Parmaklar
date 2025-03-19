namespace Akilli_Parmaklar.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
