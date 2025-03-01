using commander.Models;

namespace commander.Data
{
    public interface IPhoneRepo
    {
        IEnumerable<Phone> GetAppPhones();
        Phone GetPhoneById(int id);
       
    }
}