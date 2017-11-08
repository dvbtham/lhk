namespace LeHuuKhoa.Core.Models
{
    public class File
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string FileSize { get; set; }

        public FileType FileType { get; set; }
    }

    public enum FileType
    {
        Image = 1,
        Document = 10
    }
}