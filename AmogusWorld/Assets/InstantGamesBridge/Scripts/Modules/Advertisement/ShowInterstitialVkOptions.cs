using System;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialVkOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialVkOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
        }
    }
}