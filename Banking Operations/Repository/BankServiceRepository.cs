using Banking_Operations.Data;
using Banking_Operations.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banking_Operations.Repository
{
    public class BankServiceRepository : IBankServicesRepository
    {
        private ApplicationDBContext _context;
        public BankServiceRepository(ApplicationDBContext context) 
        {
            _context = context;
        }
        public bool Add(BankService bankService)
        {
            _context.Add(bankService);
            return Save();
        }

        public bool Delete(BankService bankService)
        {
            _context.Remove(bankService);
            return Save();
        }

        public async Task<IEnumerable<BankService>> GetAll()
        {
            return await _context.BankServices.ToListAsync();
        }

        public async Task<IEnumerable<BankService>> GetByClientIdAsync(string clientId)
        {
            return await _context.BankServices.Where(x => x.ClientId.Contains(clientId)).ToListAsync();
        }

        public async Task<BankService> GetByIdAsync(int id)
        {
            return await _context.BankServices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(BankService bankService)
        {
            _context.Update(bankService);
            return Save();
        }
    }
}
