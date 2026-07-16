using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Suppliers
{
    public class CreateSupplierRequest : IRequest<CreateSupplierResponse>
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Contact { get; set; }
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string Address { get; set; }
        public string? Remark { get; set; }
    }
}
