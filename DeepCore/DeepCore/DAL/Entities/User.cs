using System;

namespace DeepCore.DAL.Entities
{
    public class User
    {
        public long Id { get; set; }

        public Guid PublicUserId { get; set; }

        public string UserName { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? RealName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int Status { get; set; }

        public DateTime? CreatedTime { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
