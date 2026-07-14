using System;
using System.Collections.Generic;

namespace DeepCore.DAL.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Unit { get; set; } = null!;

        public decimal PurchasePrice { get; set; } = 0m;

        public decimal SalePrice { get; set; } = 0m;

        public int Status { get; set; } = 1;

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
    }
}
