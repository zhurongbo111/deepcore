using DeepCore.RequestHandlers.Shared;

namespace DeepCore.RequestHandlers.Products
{
    public class CreateProductResponse : BaseResponse
    {
        public long Id { get; set; }

        public bool CodeExist { get; set; }
    }
}
