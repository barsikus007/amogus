using System;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialYandexOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialYandexOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
        }
    }
}