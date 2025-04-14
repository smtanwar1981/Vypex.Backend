using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.Employee.Common.Core
{
    public class VypexServiceResult<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string ErrorMessage { get; }
        public int? ErrorCode { get; }

        public VypexServiceResult(bool isSuccess, T value, string errorMessage, int? errorCode)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public static VypexServiceResult<T> Success(T value) => new VypexServiceResult<T>(true, value, null, null);
        public static VypexServiceResult<T> Failure(string errorMessage, int? errorCode = null) => new VypexServiceResult<T>(false, default, errorMessage, errorCode);
    }
}
