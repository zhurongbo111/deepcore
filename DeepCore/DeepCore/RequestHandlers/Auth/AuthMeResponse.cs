namespace DeepCore.RequestHandlers.Auth
{
    public class AuthMeResponse
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public int Status { get; set; }
    }
}
