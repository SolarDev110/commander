using commander.Models;

namespace commander.Data
{
    public interface IRateRepo
    {
        IEnumerable<Rate> GetAllRates();
        Rate GetRateById(int id);
        
    }
}