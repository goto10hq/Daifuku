using System;
using System.Text;

namespace Daifuku.Builders
{
    static class FeaturePolicyBuilder
    {
        internal static string Build(FeaturePolicy policy)
        {
            var stringBuilder = new StringBuilder();

            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            if (policy.Accelerometer?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Accelerometer);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Accelerometer)).Append("; ");
            }

            if (policy.AmbientLightSensor?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.AmbientLightSensor);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.AmbientLightSensor)).Append("; ");
            }

            if (policy.Autoplay?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Autoplay);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Autoplay)).Append("; ");
            }

            if (policy.Camera?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Camera);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Camera)).Append("; ");
            }

            if (policy.EncryptedMedia?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.EncryptedMedia);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.EncryptedMedia)).Append("; ");
            }

            if (policy.Fullscreen?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Fullscreen);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Fullscreen)).Append("; ");
            }

            if (policy.Geolocation?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Geolocation);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Geolocation)).Append("; ");
            }

            if (policy.Gyroscope?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Gyroscope);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Gyroscope)).Append("; ");
            }

            if (policy.Magnetometer?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Magnetometer);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Magnetometer)).Append("; ");
            }

            if (policy.Microphone?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Microphone);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Microphone)).Append("; ");
            }

            if (policy.Midi?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Midi);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Midi)).Append("; ");
            }

            if (policy.Payment?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Payment);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Payment)).Append("; ");
            }

            if (policy.PictureInPicture?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.PictureInPicture);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.PictureInPicture)).Append("; ");
            }

            if (policy.Speaker?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Speaker);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Speaker)).Append("; ");
            }

            if (policy.SyncXhr?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.SyncXhr);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.SyncXhr)).Append("; ");
            }

            if (policy.Usb?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Usb);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Usb)).Append("; ");
            }

            if (policy.Vr?.Count > 0)
            {
                stringBuilder.Append(Constants.Features.Vr);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.Vr)).Append("; ");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}