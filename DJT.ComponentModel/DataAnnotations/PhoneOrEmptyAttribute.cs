using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class PhoneOrEmptyAttribute : DataTypeAttribute
    {
        public PhoneOrEmptyAttribute()
            : base(DataType.PhoneNumber)
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

            PhoneAttribute phoneAttribute = new();
            return phoneAttribute.IsValid(value);
        }
        
    }
}
