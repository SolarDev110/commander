using System.ComponentModel.DataAnnotations;

namespace commander.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int FromPhoneId { get; set; }
        public int ToPhoneId { get; set; }
       
        [Required]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
       
        public Phone FromPhone { get; set; }
        
        public Phone ToPhone { get; set; }
       
    }
}