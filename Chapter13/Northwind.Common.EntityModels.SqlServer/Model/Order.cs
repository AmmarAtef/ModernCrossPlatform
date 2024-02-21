using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("OrderID")]
        public long OrderId { get; set; }
        [Column("CustomerID")]
        public string? CustomerId { get; set; }
        [Column("EmployeeID")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? OrderDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? RequiredDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? ShippedDate { get; set; }
        public long? ShipVia { get; set; }
        [Column(TypeName = "NUMERIC")]
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("EmployeeId")]
        [InverseProperty("Orders")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey("ShipVia")]
        [InverseProperty("Orders")]
        public virtual Shipper? ShipViaNavigation { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
