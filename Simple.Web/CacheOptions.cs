namespace Simple.Web
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Carries information on how to cache a resource.
    /// </summary>
    public class CacheOptions
    {
        /// <summary>
        /// Use this single instance to disable caching.
        /// </summary>
        public static readonly CacheOptions DisableCaching = new CacheOptions();

        private readonly DateTime? _absoluteExpiry;
        private readonly TimeSpan? _slidingExpiry;

        private CacheOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOptions"/> class.
        /// </summary>
        /// <param name="absoluteExpiry">The absolute expiry time.</param>
        /// <remarks>Use this constructor when you want to specify absolute expiry.</remarks>
        public CacheOptions(DateTime absoluteExpiry)
        {
            _absoluteExpiry = absoluteExpiry;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOptions"/> class.
        /// </summary>
        /// <param name="slidingExpiry">The sliding expiry time.</param>
        /// <remarks>Use this constructor when you want to specify sliding expiry.</remarks>
        public CacheOptions(TimeSpan slidingExpiry)
        {
            _slidingExpiry = slidingExpiry;
        }

        /// <summary>
        /// Gets the sliding expiry time.
        /// </summary>
        public TimeSpan? SlidingExpiry
        {
            get { return _slidingExpiry; }
        }

        /// <summary>
        /// Gets the absolute expiry time.
        /// </summary>
        public DateTime? AbsoluteExpiry
        {
            get { return _absoluteExpiry; }
        }

        /// <summary>
        /// Gets a value indicating whether caching should be disabled for a resource.
        /// </summary>
        /// <value>
        ///   <c>true</c> if caching should be disabled; otherwise, <c>false</c>.
        /// </value>
        public bool Disable
        {
            get { return !(_slidingExpiry.HasValue || _absoluteExpiry.HasValue); }
        }

        public ICollection<string> VaryByHeaders { get; set; }

        public ICollection<string> VaryByParams { get; set; }

        public ICollection<string> VaryByContentEncodings { get; set; } 
    }
}