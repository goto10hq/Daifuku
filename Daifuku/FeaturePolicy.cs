using System.Collections.Generic;

namespace Daifuku
{
    /// <summary>
    /// Feature policy.
    /// </summary>
    /// <remarks>https://github.com/WICG/feature-policy/blob/master/features.md</remarks>
    public class FeaturePolicy
    {
        /// <summary>
        /// Controls access to accelerometer sensors on the device.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Accelerometer { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to ambient light sensors on the device.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> AmbientLightSensor { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to autoplay through play() and autoplay.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Autoplay { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to autoplay through play() and autoplay.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Camera { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to autoplay through play() and autoplay.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> EncryptedMedia { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls whether requestFullscreen() is allowed.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Fullscreen { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to Geolocation interface.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Geolocation { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to gyroscope sensors on the device.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Gyroscope { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to gyroscope sensors on the device.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Magnetometer { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to audio input devices.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Microphone { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to requestMIDIAccess() method.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Midi { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to PaymentRequest interface.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Payment { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to Picture in Picture.
        /// </summary>
        /// <remarks>Default value: *</remarks>
        public HashSet<string> PictureInPicture { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to audio output devices.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Speaker { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls whether synchronous XMLHttpRequest transfers are allowed.
        /// </summary>
        /// <remarks>Default value: *</remarks>
        public HashSet<string> SyncXhr { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to USB devices.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Usb { get; set; } = new HashSet<string>();

        /// <summary>
        /// Controls access to VR displays.
        /// </summary>
        /// <remarks>Default value: self</remarks>
        public HashSet<string> Vr { get; set; } = new HashSet<string>();
    }
}