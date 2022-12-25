﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurcheseWork.Models
{
    [Table("tblPurchaseDetails")]
    public partial class TblPurchaseDetail
    {
        [Key]
        [Column("intDetailsId")]
        public int IntDetailsId { get; set; }
        [Column("intPurchaseId")]
        public int? IntPurchaseId { get; set; }
        [Column("intItemId")]
        public int? IntItemId { get; set; }
        [Column("numItemQuantity", TypeName = "numeric(18, 2)")]
        public decimal? NumItemQuantity { get; set; }
        [Column("numUnitPrice", TypeName = "numeric(18, 2)")]
        public decimal? NumUnitPrice { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
    }
}
