using System.ComponentModel.DataAnnotations;

namespace Banking_Operations.Data
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }
        public string? Town { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public long? PostalCode { get; set; }
    }
}
