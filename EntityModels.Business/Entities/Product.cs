﻿namespace EntityModels.Core.Entities
{
    public class Product
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? ItemPrice { get; set; }
    }
}