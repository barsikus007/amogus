using System;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class ShowNativePopupVkOptions : ShowNativePopupPlatformDependedOptions
    {
        public int userResult;

        public bool global;

        public ShowNativePopupVkOptions(int userResult, bool global)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
            this.userResult = userResult;
            this.global = global;
        }
    }
}