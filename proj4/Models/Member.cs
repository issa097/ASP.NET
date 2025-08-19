using System.ComponentModel.DataAnnotations;

namespace proj4.Models
{
    public abstract class Member
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public virtual string MemberType { get; set; } = string.Empty;


        public abstract double CalculateLateFee(int daysLate);

    }
}
