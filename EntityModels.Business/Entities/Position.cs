namespace EntityModels.Core.Entities
{
    public class Position
    {
        public int PositionId { get; set; }
        public string? PositionName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}

