using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.Results
{
    public enum ResultCode
    {
        /// <summary>
        /// The request succeded
        /// </summary>
        Success = 200,

        /// <summary>
        /// The request was not appropriate and failed
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// The requested resource was not found
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// There was a conflict
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// An error occurred server-side
        /// </summary>
        Error = 500
    };
}
