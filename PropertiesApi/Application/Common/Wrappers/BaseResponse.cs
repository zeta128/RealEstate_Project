using PropertiesApi.Domain.Options.Pagination;
using System.Text.Json.Serialization;

namespace PropertiesApi.Application.Common.Wrappers
{
    public class BaseResponse<T>
    {

        public BaseResponse()
        {

        }

        public BaseResponse(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public BaseResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public BaseResponse(MetaData metaData, T data)
        {
            Succeeded = true;
            MetaData = metaData;
            Data = data;
        }
        public bool Succeeded { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MetaData? MetaData { get; private set; }
        public string? Message { get; set; }
        public T Data { get; set; } = default!;

    }
}
