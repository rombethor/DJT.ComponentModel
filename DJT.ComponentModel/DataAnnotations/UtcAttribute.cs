using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Ensure that a provided date and time is in UTC
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UtcAttribute : ValidationAttribute
    {
        public UtcAttribute()
        {
            ErrorMessage = "The date and time are not in UTC.";
        }

        public override bool IsValid(object? value)
        {
            //Let null slip through
            if (value == null)
                return true;

            Type type = value.GetType();
            
            if (type == typeof(DateTime))
            {
                DateTime val = (DateTime)value;
                return val.Kind == DateTimeKind.Utc;
            }
            if (type == typeof(DateTimeOffset))
            {
                DateTimeOffset val = (DateTimeOffset)value;
                return val.Offset == TimeSpan.Zero;
            }
            if (type == typeof(DateOnly))
            {
                //DateOnly ignores timezone
                return true;
            }
            if (type == typeof(TimeOnly))
            {
                //TimeOnly ignores timezone
                return true;
            }
            //experimental pre-parsing of strings
            if (type == typeof(string))
            {
                if (DateTime.TryParse((string)value, out DateTime result))
                    return result.Kind == DateTimeKind.Utc;
                if (DateTimeOffset.TryParse((string)value, out DateTimeOffset dto))
                    return dto.Offset == TimeSpan.Zero;
            }

            throw new ArgumentException("Type provided to UtcAttribute is not DateTime, DateTimeOffset, DateOnly or TimeOnly");
        }
    }
}
