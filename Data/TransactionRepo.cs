using System.Transactions;
using commander.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Transaction = commander.Models.Transaction;

namespace commander.Data
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly AppDBContext _dbcontext;

        public TransactionRepo(AppDBContext appDBContext)
        {
            _dbcontext = appDBContext;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _dbcontext.Transactions.ToList();
        }

        public void Transact()
        {
             
            DateTime date = DateTime.Parse("2024-01-04 00:00:00.0000000");
            Models.Transaction transaction = new Models.Transaction()
            {
                FromPhoneId = 1,
                ToPhoneId = 2,
                Amount = 5
            };
            Rate? fromrate = _dbcontext.Rates
            .FirstOrDefault(x => x.Date == date && x.PhoneId == 1);
            Rate? torate = _dbcontext.Rates
            .FirstOrDefault(x => x.Date == date && x.PhoneId == 2);

            fromrate.Amount -= transaction.Amount;
            torate.Amount += transaction.Amount;

            _dbcontext.Update(fromrate);
            _dbcontext.Update(torate);
            _dbcontext.Add(transaction);
            _dbcontext.SaveChanges();
        }

        public void Use ()
        {
             DateTime date = DateTime.Parse("2024-01-02 00:00:00.0000000");
             Rate? rate = _dbcontext.Rates.FirstOrDefault(x=>x.Date==date && x.PhoneId==1);

             rate.Amount -= 3;
             _dbcontext.Update(rate);
             _dbcontext.SaveChanges();
        }
    }
}