using System.Transactions;
using commander.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace commander.Data
{
    public class TransactionRepo
    {
        private readonly AppDBContext _dbcontext;

        public TransactionRepo(AppDBContext appDBContext)
        {
            _dbcontext = appDBContext;
        }

        public IEnumerable<Trans> GetAllTransactions()
        {
            return _dbcontext.Transactions.ToList();
        }

        public void Transact()
        {
             
            DateTime date = DateTime.Parse("2024-01-04 00:00:00.0000000");
            Trans trans = new Trans()
            {
                FromPhoneId = 1,
                ToPhoneId = 2,
                Amount = 5
            };
            Rate fromrate = _dbcontext.Rates
            .FirstOrDefault(x => x.Date == date && x.PhoneId == 1);
            Rate torate = _dbcontext.Rates
            .FirstOrDefault(x => x.Date == date && x.PhoneId == 2);

            fromrate.Amount -= trans.Amount;
            torate.Amount += trans.Amount;

            _dbcontext.Update(fromrate);
            _dbcontext.Update(torate);
            _dbcontext.Add(trans);
            _dbcontext.SaveChanges();
        }

        public void Use ()
        {
             DateTime date = DateTime.Parse("2024-01-02 00:00:00.0000000");
             Rate rate = _dbcontext.Rates.FirstOrDefault(x=>x.Date==date && x.PhoneId==1);

             rate.Amount -= 3;
             _dbcontext.Update(rate);
             _dbcontext.SaveChanges();
        }
    }
}