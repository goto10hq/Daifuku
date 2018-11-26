using System;

namespace Daifuku.Services
{
    /// <summary>
    /// Universal time interface.
    /// </summary>
    public interface IUniversalTime
    {
        /// <summary>
        /// Get current datetime.
        /// </summary>        
        DateTime Now { get; }
    }
}