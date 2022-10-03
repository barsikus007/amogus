using System;

namespace InstantGamesBridge.Modules.Social
{
    [Serializable]
    public class JoinCommunityVkOptions : JoinCommunityPlatformDependedOptions
    {
        public int groupId;

        public JoinCommunityVkOptions(int groupId)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
            this.groupId = groupId;
        }
    }
}