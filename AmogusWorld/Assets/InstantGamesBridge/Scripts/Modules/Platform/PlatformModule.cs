#if UNITY_WEBGL
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Platform
{
    public class PlatformModule
    {
#if !UNITY_EDITOR
        public string id { get; } = InstantGamesBridgeGetPlatformId();

        public string language { get; } = InstantGamesBridgeGetPlatformLanguage();

        public string payload { get; } = InstantGamesBridgeGetPlatformPayload();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformId();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformLanguage();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformPayload();
#else
        public string id { get; } = "mock";

        public string language { get; } = "en";

        public string payload { get; } = null;
#endif
    }
}
#endif