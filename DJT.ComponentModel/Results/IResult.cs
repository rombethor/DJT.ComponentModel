using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.Results
{
    public interface IResult
    {
        /// <summary>
        /// The state of the response
        /// </summary>
        ResultCode State { get; }

        /// <summary>
        /// Any message related to the data
        /// </summary>
        string Message { get; }
        
        /// <summary>
        /// Boxed data
        /// </summary>
        object? Body { get; }

        /// <summary>
        /// Validation results
        /// </summary>
        IEnumerable<ValidationResult> ValidationResults { get; }
    }
}
