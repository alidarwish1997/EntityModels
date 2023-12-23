using EntityModels;

namespace EntityModels
{
    public class Employee : Person
    {
        public string? Department { get; set; }
        public string? JobDescription { get; set; }
        public decimal? MonthlySalary { get; set; }
        public Employee? Manager { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public int? ManagerId { get; set; }
    }
}
    public class Position
    {
        public int PositionId { get; set; }
        public string? PositionName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }



