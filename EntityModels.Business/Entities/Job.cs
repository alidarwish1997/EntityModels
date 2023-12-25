using EntityModels.Core.Entities.Base;

namespace EntityModels.Core.Entities
{
    public class Job : Entity
    {
        public string? Name { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
