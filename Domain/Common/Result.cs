using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Result
    {
        private Result(bool isSuccess, string errorMessage, object? data = null)
        {
            if (!isSuccess && string.IsNullOrEmpty(errorMessage)) throw new Exception("string errorMessage cannot be null or empty on Failure!");
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string ErrorMessage { get; }
        public object? Data { get; }

        public static Result Success() => new Result(true, "");
        public static Result Success(object data) => new Result(true, "", data);
        public static Result Failure(string errorMessage) => new Result(false, errorMessage);
    }
}
