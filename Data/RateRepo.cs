using commander.Models;
using Microsoft.EntityFrameworkCore;

namespace commander.Data
{
    public class RateRepo :IRateRepo
    {
        private readonly AppDBContext _dbcontext;

        public RateRepo(AppDBContext appDBContext)
        {
            _dbcontext = appDBContext;
        }

        public IEnumerable<Rate> GetAllRates()
        {
            return _dbcontext.Rates;
        }

        public Rate GetRateById(int id)
        {
            return _dbcontext.Rates
            .FirstOrDefault(x=>x.Id==id);
        }
    }
}