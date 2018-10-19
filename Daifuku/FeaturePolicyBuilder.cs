using System;

namespace Daifuku
{
    public class FeaturePolicyBuilder
    {
        internal readonly FeaturePolicy Policy = new FeaturePolicy();

        public FeaturePolicyBuilder WithAccelerometer(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Accelerometer.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithAmbientLightSensor(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.AmbientLightSensor.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithAutoplay(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Autoplay.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithCamera(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Camera.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithEncryptedMedia(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.EncryptedMedia.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithFullscreen(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Fullscreen.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithGeolocation(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Geolocation.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithGyroscope(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Gyroscope.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithMagnetometer(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Magnetometer.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithMicrophone(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Microphone.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithMidi(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Midi.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithPayment(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Payment.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithPictureInPicture(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.PictureInPicture.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithSpeaker(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Speaker.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithSyncXhr(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.SyncXhr.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithUsb(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Usb.UnionWith(sources);
            return this;
        }

        public FeaturePolicyBuilder WithVr(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException("Default sources have not been set.", nameof(sources));

            Policy.Vr.UnionWith(sources);
            return this;
        }

        public FeaturePolicy BuildPolicy() => Policy;
    }
}