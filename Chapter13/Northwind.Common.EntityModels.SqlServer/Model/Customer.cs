using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            CustomerTypes = new HashSet<CustomerDemographic>();
        }

        [Key]
        [Column("CustomerID")]
        [RegularExpression("[A-Z]{5}")]
        public string CustomerId { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order> Orders { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Customers")]
        public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; }
    }
}
