using System.ComponentModel.DataAnnotations;

namespace proj4.Models
{
    public class MemberCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string MemberType { get; set; } // "Student" أو "Teacher"
    }
}
