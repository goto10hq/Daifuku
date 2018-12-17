using System;
using TimeZoneConverter;
using Momo.Tokens;

namespace Daifuku.Services
{
    /// <summary>
    /// Universal time.
    /// </summary>
    public class UniversalTime : IUniversalTime
    {
        readonly string _timezone;
        readonly TimeZoneInfo _timeZoneInfo;

        TimeZoneInfo _timeZoneInformation
        {
            get
            {
                if (_timeZoneInfo != null)
                    return _timeZoneInfo;

                return _timezone == null ? TimeZoneInfo.Utc : TZConvert.GetTimeZoneInfo(_timezone);
            }
        }

        /// <summary>
        /// Get current datetime.
        /// </summary>
        public DateTime Now => GetDateTime(DateTime.Now);

        /// <summary>
        /// Get datetime.
        /// </summary>
        /// <param name="dateTime">Datetime.</param>
        /// <returns>Datetime for a give time zone info.</returns>
        public DateTime GetDateTime(DateTime dateTime) => TimeZoneInfo.ConvertTime(dateTime, _timeZoneInformation);

        /// <summary>
        /// Create universal time.
        /// </summary>
        public UniversalTime()
        {
        }

        /// <summary>
        /// Initialize universal time with a given timezone.
        /// </summary>
        /// <param name="timezone">Timezone.</param>
        public UniversalTime(string timezone)
        {
            _timezone = timezone ?? throw new ArgumentNullException(nameof(timezone));
        }

        /// <summary>
        /// Initialize universal time with a given timezone.
        /// </summary>
        /// <param name="timeZoneInfo">Timezone info.</param>
        public UniversalTime(TimeZoneInfo timeZoneInfo)
        {
            _timeZoneInfo = timeZoneInfo;
        }

        /// <summary>
        /// Initialize universal time with a given timezone.
        /// </summary>
        /// <param name="configuration">Universal time configuration from Momo.Tokens.</param>
        public UniversalTime(IUniversalTimeConfiguration configuration)
        {
            _timezone = configuration.Timezone;
        }
    }
}