using System;
using System.Collections.Generic;

namespace DeepCore.DAL.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public long Id { get; set; }

        public string OrderNo { get; set; } = null!;

        public long SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public PurchaseOrderStatus Status { get; set; }

        public string? Remark { get; set; }

        public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
    }

    public enum PurchaseOrderStatus : int
    {
        Draft = 0,
        Submitted = 1,
        Canceled = 2,
        Stocked = 3
    }
}
