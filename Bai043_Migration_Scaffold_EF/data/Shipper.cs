using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bai043_Migration_Scaffold_EF.data
{
    public partial class Shipper
    {
        [Key]
        [Column("ShipperID")]
        public int ShipperId { get; set; }
        [StringLength(255)]
        public string Hoten { get; set; }
        [StringLength(255)]
        public string Sodienthoai { get; set; }
    }
}
