using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class ProductsByCategory
    {
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public long? UnitsInStock { get; set; }
        public string? Discontinued { get; set; }
    }
}
