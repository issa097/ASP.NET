using proj4.Interfaces;

namespace proj4.Models
{
    public class TeacherMember : Member, IBorrowable
    {
        public TeacherMember()
        {
            MemberType = "Teacher";
        }

        public TeacherMember(string name)
        {
            Name = name;
            MemberType = "Teacher";
        }

        public override double CalculateLateFee(int daysLate)
        {
            return daysLate * 0.2;
        }

        public void BorrowBook(Book book)
        {
            if (!book.IsBorrowed)
            {
                book.Borrow();
                Console.WriteLine($"Teacher {Name} borrowed '{book.Title}'.");
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
