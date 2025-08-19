using System.ComponentModel.DataAnnotations;

namespace proj4.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public bool IsBorrowed { get; set; } = false;

        public void Borrow() => IsBorrowed = true;
        public void Return() => IsBorrowed = false;
    }
}
