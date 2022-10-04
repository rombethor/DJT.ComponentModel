using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DJT.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Ensures that the provided datetime is in the future in UTC
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class FutureAttribute : ValidationAttribute
    {
        public FutureAttribute() { }

        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var type = value.GetType();
                if (type == typeof(DateTime))
                {
                    return (DateTime)value > DateTime.UtcNow;
                }
                else if(type == typeof(DateTimeOffset))
                {
                    if ((DateTimeOffset)value <= DateTimeOffset.UtcNow)
                    {
                        return false;
                    }    
                }
            }
            return true;
        }

    }
}
