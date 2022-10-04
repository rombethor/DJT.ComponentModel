using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.ComponentModel.Format
{
    /// <summary>
    /// Extension methods for pages
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// Creates a page object with these items and the specified metadata
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Items to be contained within the page</param>
        /// <param name="total">The total available items including this page</param>
        /// <param name="limit">The maximum number of items requested per page</param>
        /// <param name="offset">The number of items in sequence before this page</param>
        /// <returns>A page of data of type T</returns>
        public static Page<T> ToPage<T>(this IEnumerable<T> items, int total, int limit, int offset)
        {
            return new Page<T>(items, total, limit, offset);
        }
    }
}
