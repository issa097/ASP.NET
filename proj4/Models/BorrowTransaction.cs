namespace proj4.Models
{
    public class BorrowTransaction
    {
        public int Id { get; set; }

        public int BookId { get; set; }     
        public int MemberId { get; set; }   

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public int DaysLate { get; set; }
        public double Penalty { get; set; }

      
        public Book? Book { get; set; }
        public Member? Member { get; set; }
    }
}
