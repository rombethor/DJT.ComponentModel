using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Check if a valid URL.  Passes if null or empty.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class UrlOrEmptyAttribute : DataTypeAttribute
    {
        string[] protocols = { "https" };

        /// <summary>
        /// </summary>
        public UrlOrEmptyAttribute() : base(DataType.Url)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="protocols">Specify a list of allowed protocols.  The default is only "https"</param>
        public UrlOrEmptyAttribute(params string[] protocols) : base(DataType.Url)
        {
            this.protocols = protocols;
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            if (value is string url)
            {
                if (url == string.Empty)
                    return true;
                foreach(var protocol in protocols)
                    if (url.StartsWith($"{protocol}://"))
                        return true;
            }
            return false;
        }

    }
}
