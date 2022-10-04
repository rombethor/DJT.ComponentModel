using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DJT.ComponentModel.Format
{
    /// <summary>
    /// A page of data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T>
    {
        /// <summary>
        /// Create a blank page
        /// </summary>
        public Page()
        {
            Items = Array.Empty<T>();
            Total = 0;
            Limit = 0;
            Offset = 0;
        }

        /// <summary>
        /// Create a page from the given items and metadata
        /// </summary>
        /// <param name="items">Items to be contained within the page</param>
        /// <param name="total">The total available items including this page</param>
        /// <param name="limit">The maximum number of items requested per page</param>
        /// <param name="offset">The number of items in sequence before this page</param>
        public Page(IEnumerable<T> items, int total, int limit, int offset)
        {
            Items = items;
            Total = total;
            Limit = limit;
            Offset = offset;
        }

        /// <summary>
        /// Items to be contained within the page
        /// </summary>
        [JsonPropertyName("name")]
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// The total number of items available including those within this page
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// The maximum number of items per page
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// The number of items in sequence before this page
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
    }
}
