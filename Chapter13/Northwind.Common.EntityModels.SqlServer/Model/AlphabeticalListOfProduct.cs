using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class AlphabeticalListOfProduct
    {
        [Column("ProductID")]
        public long? ProductId { get; set; }
        public string? ProductName { get; set; }
        [Column("SupplierID")]
        public long? SupplierId { get; set; }
        [Column("CategoryID")]
        public long? CategoryId { get; set; }
        public string? QuantityPerUnit { get; set; }
        [Column(TypeName = "NUMERIC")]
        public byte[]? UnitPrice { get; set; }
        public long? UnitsInStock { get; set; }
        public long? UnitsOnOrder { get; set; }
        public long? ReorderLevel { get; set; }
        public string? Discontinued { get; set; }
        public string? CategoryName { get; set; }
    }
}
