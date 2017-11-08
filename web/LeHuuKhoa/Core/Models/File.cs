namespace LeHuuKhoa.Core.Models
{
    public class File
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int FileSize { get; set; }

        public FileType FileType { get; set; }
        
    }

    public enum FileType
    {
        Image = 1,
        Document = 10
    }
}