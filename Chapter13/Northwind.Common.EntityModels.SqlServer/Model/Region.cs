using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        [Column("RegionID")]
        public long RegionId { get; set; }
        public string RegionDescription { get; set; } = null!;

        [InverseProperty("Region")]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
