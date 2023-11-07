using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Banking_Operations.Data
{
    public class ApplicationDBContext : IdentityDbContext<Client>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
   
        }
        public DbSet<BankService> BankServices { get; set; }
        
    }
}
