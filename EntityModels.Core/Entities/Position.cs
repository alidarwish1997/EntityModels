using EntityModels.Core.Entities.Base;

namespace EntityModels.Core.Entities
{
    public class Position : Entity
    {
        public int PositionId { get; set; }
        public string? PositionName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}

