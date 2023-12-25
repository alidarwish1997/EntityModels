using EntityModels.Core.Entities.Base;

namespace EntityModels.Core.Entities
{
    public class Order : Entity
    {
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
        public bool? IsDelivered { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? IsCancelled { get; set; }
    }
}