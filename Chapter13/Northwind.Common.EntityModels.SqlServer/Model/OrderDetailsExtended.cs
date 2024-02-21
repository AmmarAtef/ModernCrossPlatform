using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class OrderDetailsExtended
    {
        [Column("OrderID")]
        public long? OrderId { get; set; }
        [Column("ProductID")]
        public long? ProductId { get; set; }
        public string? ProductName { get; set; }
        [Column(TypeName = "NUMERIC")]
        public byte[]? UnitPrice { get; set; }
        public long? Quantity { get; set; }
        public double? Discount { get; set; }
        public byte[]? ExtendedPrice { get; set; }
    }
}
