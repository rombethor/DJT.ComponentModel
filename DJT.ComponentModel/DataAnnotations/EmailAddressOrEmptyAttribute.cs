using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class EmailAddressOrEmptyAttribute : DataTypeAttribute
    {
        public EmailAddressOrEmptyAttribute() : base(DataType.EmailAddress)
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is string valueAsString))
            {
                return false;
            }

            if (valueAsString == string.Empty)
            {
                return true;
            }

            return (new EmailAddressAttribute().IsValid(value));
        }
    }
}
