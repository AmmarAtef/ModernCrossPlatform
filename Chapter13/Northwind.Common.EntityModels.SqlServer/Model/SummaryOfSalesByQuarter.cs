using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class SummaryOfSalesByQuarter
    {
        [Column(TypeName = "DATETIME")]
        public byte[]? ShippedDate { get; set; }
        [Column("OrderID")]
        public long? OrderId { get; set; }
        public byte[]? Subtotal { get; set; }
    }
}
