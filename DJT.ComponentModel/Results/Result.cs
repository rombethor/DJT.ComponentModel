using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.Results
{
    /// <summary>
    /// A typed result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : AResult, IResult<T>
    {
        /// <summary>
        /// Create a new typed result from data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        public Result(T data, ResultCode code = ResultCode.Success) : base(code, "OK", data, null)
        {
            _body = data;
            _code = code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public Result(IResult result)
        {
            _body = result.Body;
            _code = result.State;
            _message = result.Message;
            _validationResults = result.ValidationResults;
        }

        /// <summary>
        /// Resulting data
        /// </summary>
        public T? Data => _body == null ? default : (T)_body;

        /// <summary>
        /// Implicit conversion from Result to typed Result
        /// </summary>
        /// <param name="reply"></param>
        public static implicit operator Result<T>(Result reply) => new Result<T>(reply);
    }

    public class Result : AResult, IResult
    {
        public Result() { }

        public Result(ResultCode state, string message = "", object? body = null, IEnumerable<ValidationResult>? validationResults = null)
        {
            _code = state;
            _message = message;
            if (_body != null)
            {
                _body = null;
            }
            if (validationResults != null)
            {
                _validationResults = validationResults;
            }
        }

        //protected ResultCode _code;
        //protected string _message = string.Empty;
        //protected object? _body = null;
        //protected IEnumerable<ValidationResult> _validationResults = Array.Empty<ValidationResult>();

        //public ResultCode State => _code;
        //public string Message => _message;
        //public object? Body => _body;
        //public IEnumerable<ValidationResult> ValidationResults => _validationResults;

        public static IResult Success()
            => new Result(ResultCode.Success, "OK");

        public static IResult Success(object body)
            => new Result(ResultCode.Success, "OK", body);

        public static IResult<T> Success<T>(T body)
            => new Result<T>(body);

        public static IResult NotFound(string message = "")
            => new Result(ResultCode.NotFound);

        public static IResult BadRequest(string message = "")
            => new Result(ResultCode.BadRequest);

        public static IResult BadRequest(IEnumerable<ValidationResult> validationResults, string message = "")
            => new Result(ResultCode.BadRequest, message, null, validationResults);

        public static IResult Conflict(string message = "")
            => new Result(ResultCode.Conflict, message);

        public static IResult Error(string message)
            => new Result(ResultCode.Error, message);
    }
}
