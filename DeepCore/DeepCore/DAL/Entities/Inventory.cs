using System;

namespace DeepCore.DAL.Entities
{
    public class Inventory : BaseEntity
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public Product? Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal LockedQuantity { get; set; }

        public decimal AvailableQuantity { get; set; }
    }
}
