using EntityModels.Core.Entities.Base;

namespace EntityModels.Core.Entities
{
    public class Person  : Entity
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public ContactInfo? ContactInfo { get; set; }
        public int? Age { get; set; }
    }
}