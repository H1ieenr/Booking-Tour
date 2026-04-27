
namespace Application.Common
{
    public class ImageSettings
    {
        public string RootFolder { get; set; } = string.Empty;
        public int MaxFileSize { get; set; }
        public List<string> AllowedExtensions { get; set; } = new();
    }
}