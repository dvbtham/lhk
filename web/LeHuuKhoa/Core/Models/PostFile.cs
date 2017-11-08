namespace LeHuuKhoa.Core.Models
{
    public class PostFile
    {
        public long PostId { get; set; }
        public virtual Post Post { get; set; }

        public long FileId { get; set; }
        public virtual File File { get; set; }
    }
}