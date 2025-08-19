using Microsoft.EntityFrameworkCore;
using proj4.Models;

namespace proj4.data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasDiscriminator<string>("MemberType")
               
                .HasValue<StudentMember>("Student")
                .HasValue<TeacherMember>("Teacher");

        }
    }
}
