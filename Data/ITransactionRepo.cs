using commander.Models;


namespace commander.Data
{
    public interface ITransactionRepo
    {
        IEnumerable<Transaction> GetAllTransactions();
        void Transact();
        void Use();

    }
}
