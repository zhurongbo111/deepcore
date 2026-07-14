using System;
using System.Collections.Generic;

namespace DeepCore.DAL.Entities
{
    public class PurchaseOrder
    {
        public long Id { get; set; }

        public string OrderNo { get; set; } = null!;

        public long SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int Status { get; set; }

        public string? Remark { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
    }
}
