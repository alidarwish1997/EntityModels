namespace EntityModels.Core.Entities
{
    public class Customer : Person
    {
        public int? AccountNumber { get; set; }
        public string? LoyaltyNumber { get; set; }
        public string? BankName { get; set; }
    }
}
