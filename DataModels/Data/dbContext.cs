using Microsoft.EntityFrameworkCore;

namespace DataModels
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public DbSet<mBoard> mBoards { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mBoard>().ToTable("mBoard");
           
        }

    }
}
