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
    public class Result<T> : AResult, IResult
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

        /// <summary>
        /// Implicit conversion from typed result to plain result
        /// </summary>
        /// <param name="r"></param>
        public static implicit operator Result(Result<T> r) => new Result(r);
    }

    /// <summary>
    /// A wrapper for repository pattern responses, indicating a state
    /// and containing the data and/or validation data.
    /// </summary>
    public class Result : AResult, IResult
    {
        /// <summary>
        /// Create this result as a copy of another
        /// </summary>
        /// <param name="result"></param>
        public Result(IResult result) : base(result) { }

        /// <summary>
        /// Create a blank result
        /// </summary>
        public Result() { }

        /// <summary>
        /// Create a result via parameters
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        /// <param name="body"></param>
        /// <param name="validationResults"></param>
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

        
        /// <summary>
        /// Create a blank successful result
        /// </summary>
        /// <returns></returns>
        public static Result Success()
            => new Result(ResultCode.Success, "OK");

        /// <summary>
        /// Create a successful result with data
        /// </summary>
        /// <param name="body">The boxed data to include in the result</param>
        /// <returns></returns>
        public static Result Success(object body)
            => new Result(ResultCode.Success, "OK", body);

        /// <summary>
        /// Create a typed successful result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Result<T> Success<T>(T body)
            => new Result<T>(body, ResultCode.Success);

        /// <summary>
        /// Create a result for resource not found
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result NotFound(string message = "")
            => new Result(ResultCode.NotFound);

        /// <summary>
        /// Create a result for a forbidden request
        /// </summary>
        /// <returns></returns>
        public static Result Forbidden()
            => new Result(ResultCode.Forbidden);

        /// <summary>
        /// Create a result for invalid requests
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result BadRequest(string message = "")
            => new Result(ResultCode.BadRequest);

        /// <summary>
        /// Create a result for invalid requests, including validation results.
        /// </summary>
        /// <param name="validationResults"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result BadRequest(IEnumerable<ValidationResult> validationResults, string message = "")
            => new Result(ResultCode.BadRequest, message, null, validationResults);

        /// <summary>
        /// Create a result for requests failing due to a conflict of resources
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Conflict(string message = "") 
            => new Result(ResultCode.Conflict, message);

        /// <summary>
        /// Create a result for error encountered in the application
        /// </summary>
        /// <param name="message">A descriptive message</param>
        /// <returns></returns>
        public static Result Error(string message)
            => new Result(ResultCode.Error, message);
    }
}
