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

        /// <summary>
        /// Get datetime.
        /// </summary>
        /// <param name="dateTime">Datetime.</param>
        /// <returns>Datetime for a give time zone info.</returns>
        DateTime GetDateTime(DateTime dateTime);
    }
}