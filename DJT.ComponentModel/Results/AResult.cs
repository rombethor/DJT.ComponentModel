using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.Results
{
    /// <summary>
    /// Abstract base implementation of IResult
    /// </summary>
    public abstract class AResult
    {
        /// <summary>
        /// Blank result
        /// </summary>
        public AResult() { }

        /// <summary>
        /// Create a copy result
        /// </summary>
        /// <param name="result"></param>
        public AResult(IResult result)
        {
            _body = result.Body;
            _code = result.State;
            _message = result.Message;
            _validationResults = result.ValidationResults;
        }

        public AResult(ResultCode state, string message = "", object? body = null, IEnumerable<ValidationResult>? validationResults = null)
        {
            _code = state;
            _message = message;
            if (_body != null)
            {
                _body = null;
            }
            if (validationResults != null)
            {

            }
        }

        /// <summary>
        /// A code defining the state of the response
        /// </summary>
        protected ResultCode _code = ResultCode.Success;

        /// <summary>
        /// A message describing the response
        /// </summary>
        protected string _message = string.Empty;

        /// <summary>
        /// The body of the response, the data required as boxed
        /// </summary>
        protected object? _body = null;

        /// <summary>
        /// Validation results of the original request
        /// </summary>
        protected IEnumerable<ValidationResult> _validationResults = Array.Empty<ValidationResult>();

        /// <summary>
        /// A code defining the state of the result.  
        /// </summary>
        public ResultCode State => _code;

        /// <summary>
        /// A message describing the result.
        /// </summary>
        public string Message => _message;

        /// <summary>
        /// The resulting data
        /// </summary>
        public object? Body => _body;

        /// <summary>
        /// Validation results of the original request
        /// </summary>
        public IEnumerable<ValidationResult> ValidationResults => _validationResults;
    }
}
