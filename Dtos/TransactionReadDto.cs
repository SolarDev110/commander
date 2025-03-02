using System.ComponentModel.DataAnnotations;

namespace commander.Dtos
{
    public class TransactionReadDto
    {
        public int Id { get; set; }
        public int FromPhoneId { get; set; }
        public int ToPhoneId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
