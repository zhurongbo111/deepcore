using System;
using System.Collections.Generic;

namespace DeepCore.DAL.Entities
{
    public class SalesOrder
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string OrderNo { get; set; } = null!;

        public Customer? Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int Status { get; set; }

        public string? Remark { get; set; }
        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public ICollection<SalesOrderItem> Items { get; set; } = new List<SalesOrderItem>();
    }
}
