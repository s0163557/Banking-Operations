namespace Banking_Operations.Models
{
    public class BankingModel
    {
        public int ServiceID { get; set; }
        public string? BankServiceName { get; set; }
        public string? TermOfRendering { get; set; }
        public string? ComissionType { get; set; }
        public int? Debt { get; set; }
        public string? ClientId { get; set; }
    }
}
