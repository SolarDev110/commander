using commander.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace commander.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                    .HasOne(t => t.FromPhone)
                    .WithMany(p => p.SentTransactions)
                    .HasForeignKey(t => t.FromPhoneId)
                    .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(t => t.ToPhone)
                .WithMany(p => p.ReceivedTransactions)
                .HasForeignKey(t => t.ToPhoneId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
