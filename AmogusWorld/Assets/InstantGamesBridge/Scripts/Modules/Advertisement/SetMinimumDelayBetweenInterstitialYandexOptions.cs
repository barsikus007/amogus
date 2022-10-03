using System;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class SetMinimumDelayBetweenInterstitialYandexOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialYandexOptions(int seconds) : base(seconds)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
        }
    }
}