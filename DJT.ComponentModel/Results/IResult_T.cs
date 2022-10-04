namespace DJT.ComponentModel.Results
{
    /// <summary>
    /// A types version of the <see cref="IResult"/>
    /// </summary>
    /// <typeparam name="T">The type of the data</typeparam>
    public interface IResult<T> : IResult {
        /// <summary>
        /// The data contained int he result
        /// </summary>
        T? Data { get; }
    }
}
