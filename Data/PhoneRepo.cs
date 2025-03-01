using commander.Models;
using Microsoft.EntityFrameworkCore;

namespace commander.Data
{
    public class PhoneRepo : IPhoneRepo
    {
        private readonly AppDBContext _dbcontext;

        public PhoneRepo(AppDBContext appDBContext)
        {
            _dbcontext = appDBContext;
        }
        public IEnumerable<Phone> GetAppPhones()
        {
            return _dbcontext.Phones
            .ToList();
        }

        public Phone GetPhoneById(int id)
        {
            return _dbcontext.Phones
            .FirstOrDefault(x => x.Id == id)
            
            ;
        }



    }
}