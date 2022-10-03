using System;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class SetMinimumDelayBetweenInterstitialVkOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialVkOptions(int seconds) : base(seconds)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
        }
    }
}