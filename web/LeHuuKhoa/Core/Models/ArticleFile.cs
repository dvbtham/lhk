namespace LeHuuKhoa.Core.Models
{
    public class ArticleFile
    {
        public long ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public long FileId { get; set; }

        public virtual File File { get; set; }
    }
}