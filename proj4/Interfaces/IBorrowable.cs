using proj4.Models;

namespace proj4.Interfaces
{
    public interface IBorrowable
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }
}
