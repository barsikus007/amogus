using System;

namespace InstantGamesBridge.Modules.Social
{
    [Serializable]
    public class ShareVkOptions : SharePlatformDependedOptions
    {
        public string link;

        public ShareVkOptions(string link)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
            this.link = link;
        }
    }
}