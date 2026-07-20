using System;
using System.Collections.Generic;

namespace DeepCore.DAL.Entities
{
    public class SalesOrder : BaseEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string OrderNo { get; set; } = null!;

        public Customer? Customer { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public SalesOrderStatus Status { get; set; }

        public string? Remark { get; set; }

        public ICollection<SalesOrderItem> Items { get; set; } = new List<SalesOrderItem>();
    }

    public enum SalesOrderStatus : int
    {
        Draft = 0,
        Submitted = 1,
        Canceled = 2,
        StockedOut = 3
    }
}
