using System;
using System.Collections.Generic;

namespace DeepCore.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string ContactName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string? Remark { get; set; }

        public int Status { get; set; } = 1;

        public ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
    }
}
