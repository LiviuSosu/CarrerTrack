
namespace CarrerTrack.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Source { get; set; }
        public bool IsRead { get; set; }

        public string Notes { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

        //added a flag to mark if a link is broken or not
        public bool BrokenLink { get; set; }
    }
}
