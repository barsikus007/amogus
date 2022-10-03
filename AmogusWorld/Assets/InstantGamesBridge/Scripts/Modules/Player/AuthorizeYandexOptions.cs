using System;

namespace InstantGamesBridge.Modules.Player
{
    [Serializable]
    public class AuthorizeYandexOptions : AuthorizePlatformDependedOptions
    {
        public bool scopes;

        public AuthorizeYandexOptions(bool scopes)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
            this.scopes = scopes;
        }
    }
}