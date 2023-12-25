using EntityModels.Core.Entities.Base;
using System.Net;

namespace EntityModels.Core.Entities
{
    public class ContactInfo : Entity
    {
        public Address? Address { get; set; }
        public string? PersonalEmail { get; set; }
        public string? WorkEmail { get; set; }
        public string? MobilePhone { get; set; }
        public string? OtherPhone { get; set; }

    }
}
