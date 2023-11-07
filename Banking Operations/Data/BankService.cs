using System.ComponentModel.DataAnnotations;

namespace Banking_Operations.Data
{
    public class BankService
    {
        [Key]
        public int ID { get; set; }
        public string BankServiceName { get; set; }
        public string TermOfRendering { get; set; }
        public string ComissionType { get; set; }
        public int Debt { get; set; }
        public bool BankServiceStatus { get; set; }
    }
}
