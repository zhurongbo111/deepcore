using System;

namespace DeepCore.DAL.Entities
{
    public class Inventory
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public Product? Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal LockedQuantity { get; set; }

        public decimal AvailableQuantity { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
