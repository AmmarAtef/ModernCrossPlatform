using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class SalesTotalsByAmount
    {
        public byte[]? SaleAmount { get; set; }
        [Column("OrderID")]
        public long? OrderId { get; set; }
        public string? CompanyName { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? ShippedDate { get; set; }
    }
}
