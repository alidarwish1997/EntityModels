using EntityModels.Core.Entities.Base;

namespace EntityModels.Core.Entities
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string DirectionNotes { get; set; }
    }
}