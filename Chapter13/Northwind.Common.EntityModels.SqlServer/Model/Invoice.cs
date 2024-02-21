using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class Invoice
    {
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        [Column("CustomerID")]
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public byte[]? Salesperson { get; set; }
        [Column("OrderID")]
        public long? OrderId { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? OrderDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? RequiredDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? ShippedDate { get; set; }
        public string? ShipperName { get; set; }
        [Column("ProductID")]
        public long? ProductId { get; set; }
        public string? ProductName { get; set; }
        [Column(TypeName = "NUMERIC")]
        public byte[]? UnitPrice { get; set; }
        public long? Quantity { get; set; }
        public double? Discount { get; set; }
        public byte[]? ExtendedPrice { get; set; }
        [Column(TypeName = "NUMERIC")]
        public byte[]? Freight { get; set; }
    }
}
