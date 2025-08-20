using System.ComponentModel.DataAnnotations;

namespace proj4.Models
{
    public class MemberCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string MemberType { get; set; } = string.Empty; // Student or Teacher
    }

}
