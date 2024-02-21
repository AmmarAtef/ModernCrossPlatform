using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class ProductsAboveAveragePrice
    {
        public string? ProductName { get; set; }
        [Column(TypeName = "NUMERIC")]
        public byte[]? UnitPrice { get; set; }
    }
}
