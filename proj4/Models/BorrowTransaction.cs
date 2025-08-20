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

        // دالة لحساب الغرامة بناءً على نوع العضو
        public void CalculatePenalty()
        {
            if (Member == null)
            {
                Penalty = 0;
                return;
            }

            if (Member.MemberType == "Student")
            {
                Penalty = DaysLate * 0.5;
            }
            else if (Member.MemberType == "Teacher")
            {
                Penalty = DaysLate * 0.2;
            }
            else
            {
                Penalty = DaysLate * 1; // قيمة افتراضية لأي نوع آخر
            }
        }
    }
}
