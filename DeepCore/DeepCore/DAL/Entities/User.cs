using System;

namespace DeepCore.DAL.Entities
{
    public class User : BaseEntity
    {
        public long Id { get; set; }

        public Guid PublicUserId { get; set; }

        public string UserName { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? RealName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int Status { get; set; } = 1;
    }
}
