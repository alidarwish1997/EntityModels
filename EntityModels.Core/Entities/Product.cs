using EntityModels.Core.Entities.Base;

namespace EntityModels.Core.Entities
{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? ItemPrice { get; set; }
    }
}