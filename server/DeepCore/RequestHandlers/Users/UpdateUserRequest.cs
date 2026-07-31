using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DeepCore.RequestHandlers.Users
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        [JsonIgnore]
        public long Id { get; set; }
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
    }
}
