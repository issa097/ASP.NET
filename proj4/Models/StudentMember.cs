using proj4.Interfaces;

namespace proj4.Models
{
    public class StudentMember : Member, IBorrowable
    {
        public StudentMember()
        {
            MemberType = "Student";
        }

        public StudentMember(string name)
        {
            Name = name;
            MemberType = "Student";
        }

        public override double CalculateLateFee(int daysLate)
        {
            return daysLate * 0.5;
        }

        public void BorrowBook(Book book)
        {
            if (!book.IsBorrowed)
            {
                book.Borrow();
                Console.WriteLine($"Student {Name} borrowed '{book.Title}'.");
            }
        }

        public void ReturnBook(Book book, int daysLate)
        {
            book.Return();
            double penalty = CalculateLateFee(daysLate);
            Console.WriteLine($"{Name} returned '{book.Title}' {daysLate} days late. Penalty: {penalty} JOD.");
        }

        public void ReturnBook(Book book)
        {
            ReturnBook(book, 0);
        }
    }
}
