using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace commander.Models
{
    public class Rate
    {
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
      
        [Required]
        public Phone Phone { get; set; }
        public int PhoneId { get; set; }
        public ICollection<Trans> Transactions{get;set;}
    }
}