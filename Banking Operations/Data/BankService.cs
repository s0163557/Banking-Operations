using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking_Operations.Data
{
    public class BankService
    {
        [Key]
        public int Id { get; set; }
        public string? BankServiceName { get; set; }
        public string? TermOfRendering { get; set; }
        public string? ComissionType { get; set; }
        public int? Debt { get; set; }
        public bool? BankServiceStatus { get; set; }
        [ForeignKey("Client")]
        public string ClientId { get; set; }
    }
}
