using System.ComponentModel.DataAnnotations;

namespace commander.Models
{

    public class Phone
    {
        public int Id { get; set; }
        [MaxLength(11)]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Transaction> SentTransactions { get; set; }   
        public ICollection<Transaction> ReceivedTransactions { get; set; }
      

    }
}