using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeepCore.RequestHandlers.Customers
{
    public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Contact { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }
        [MaxLength(500)]
        public string? Remark { get; set; }
    }
}
