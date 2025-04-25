using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace TranslatedValueApi.Domain.Result
{
    public sealed class Result
    {   
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        private Result(bool success, string message, Object data)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
        }

        private Result(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public static Result ReturnOk(string _message, Object _data)
        {
            return new Result(true, _message, _data);
        }

        public static Result ReturnError(string _message)
        {
            return new Result(false, _message);
        }
    }
}
