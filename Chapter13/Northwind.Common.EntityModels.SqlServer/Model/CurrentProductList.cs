using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Keyless]
    public partial class CurrentProductList
    {
        [Column("ProductID")]
        public long? ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
