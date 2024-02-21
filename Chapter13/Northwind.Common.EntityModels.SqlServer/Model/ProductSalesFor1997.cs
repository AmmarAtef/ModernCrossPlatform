using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class ProductSalesFor1997
    {
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public byte[]? ProductSales { get; set; }
    }
}
