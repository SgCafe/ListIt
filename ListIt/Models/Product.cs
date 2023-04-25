using System;
using System.Collections.Generic;
using System.Text;

namespace ListIt.Models
{
    public class Product
    {
        public string Name { get; set; }
        public TypeCategory TypeCategory { get; set; }
        public int? Quantity { get; set; }
        public double? Value { get; set; }
    }

    public class TypeCategory
    {
        public string Category { get; set; }
        public string Image { get; set; }
    }
}