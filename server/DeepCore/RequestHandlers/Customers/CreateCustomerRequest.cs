using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Customers
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        [Required, MaxLength(100)]
        public required string Name { get; set; }
        [Required, MaxLength(50)]
        public required string Contact { get; set; }
        [Required, MaxLength(20)]
        public required string Phone { get; set; }
        [Required, MaxLength(200)]
        public required string Address { get; set; }
        [MaxLength(500)]
        public string? Remark { get; set; }
    }
}
