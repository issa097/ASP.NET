using System.ComponentModel.DataAnnotations;

namespace proj4.Models
{
    public class LibraryViewModel
    {
        public string MemberName { get; set; } = string.Empty;
        public string MemberType { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string BookAuthor { get; set; } = string.Empty;
        public int DaysLate { get; set; }
        public List<string> Logs { get; set; } = new List<string>();
    }
}
