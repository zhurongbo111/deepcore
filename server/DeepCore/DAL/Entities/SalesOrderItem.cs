using System;

namespace DeepCore.DAL.Entities
{
    public class SalesOrderItem : BaseEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public SalesOrder? Order { get; set; }

        public Product? Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? Amount { get; set; }
    }
}
