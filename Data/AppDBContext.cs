using commander.Models;
using Microsoft.EntityFrameworkCore;

namespace commander.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Trans> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

       
            modelBuilder.Entity<Trans>()
                .HasOne(t => t.FromPhone)
                .WithMany(p => p.SentTransactions)
                .HasForeignKey(t => t.FromPhoneId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Trans>()
                .HasOne(t => t.ToPhone)
                .WithMany(p => p.ReceivedTransactions)
                .HasForeignKey(t => t.ToPhoneId)
                .OnDelete(DeleteBehavior.Restrict);

          
        }


    }
}