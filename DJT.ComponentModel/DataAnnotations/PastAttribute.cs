using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Ensures the datetime or datetimeoffset property is in the past in UTC
    /// </summary>
    public sealed class PastAttribute : ValidationAttribute
    {
        public PastAttribute() { }

        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                Type type = value.GetType();
                if (type == typeof(DateTime))
                {
                    return (DateTime)value < DateTime.UtcNow;
                }
                else if(type == typeof(DateTimeOffset))
                {
                    return (DateTimeOffset)value < DateTimeOffset.UtcNow;
                }
            }
            return true;
        }

    }
}
