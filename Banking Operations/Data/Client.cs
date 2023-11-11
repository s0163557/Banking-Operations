using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking_Operations.Data
{
    public class Client : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? SurName { get; set; }
        [ForeignKey("Adress")]
        public int? AdressId { get; set; }
        public Adress? Adress { get; set; }
        public int? Passport { get; set; }
        public ICollection<BankService> Services { get; set; }

    }
}
