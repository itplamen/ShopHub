namespace ShopHub.Services.Models.Base
{
    using ShopHub.Services.Models.Contracts;

    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(string errorMessage)
        {
            Errors = new List<string>() { errorMessage };
        }

        public bool IsSuccess => (Errors == null || !Errors.Any());

        public IEnumerable<string> Errors { get; set; }
    }

    public class BaseResponse<TResponse>
        where TResponse : class, IResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(string errorMessage)
        {
            Errors = new List<string>() { errorMessage };
        }

        public bool IsSuccess => Data != null && (Errors == null || !Errors.Any());

        public IEnumerable<string> Errors { get; set; }

        public TResponse Data { get; set; }
    }
}
