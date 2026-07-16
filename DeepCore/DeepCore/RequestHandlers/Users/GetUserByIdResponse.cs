namespace DeepCore.RequestHandlers.Users
{
    public class GetUserByIdResponse
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int Status { get; set; }
    }
}
