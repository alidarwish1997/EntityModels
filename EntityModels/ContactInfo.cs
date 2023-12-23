using System.Net;

namespace EntityModels
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public Address? Address { get; set; }
        public string? PersonalEmail { get; set; }
        public string? WorkEmail { get; set; }
        public string? MobilePhone { get; set; }
        public string? OtherPhone { get; set; }

    }
}
