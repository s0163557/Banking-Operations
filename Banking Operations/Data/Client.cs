using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Banking_Operations.Data
{
    public class Client : IdentityUser
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Adress { get; set; }
        public int Passport { get; set; }
        public ICollection<BankService> Services { get; set; } 

    }
}
