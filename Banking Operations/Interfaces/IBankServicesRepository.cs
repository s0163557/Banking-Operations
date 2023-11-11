using Banking_Operations.Data;

namespace Banking_Operations.Interfaces
{
    public interface IBankServicesRepository
    {
        Task<IEnumerable<BankService>> GetAll();
        Task<BankService> GetByIdAsync(int id);
        Task<IEnumerable<BankService>> GetByClientIdAsync(string clientId);
        bool Add(BankService bankService);
        bool Update(BankService bankService);
        bool Delete(BankService bankService);
        bool Save();
    }
}
