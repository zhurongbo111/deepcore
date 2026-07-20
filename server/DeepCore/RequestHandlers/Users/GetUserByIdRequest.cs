namespace DeepCore.RequestHandlers.Users
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public long Id { get; set; }
    }
}
