
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
namespace EntityModels
{
    public class Person
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public ContactInfo? ContactInfo { get; set; }
        public int? Age { get; set; }


    }
}