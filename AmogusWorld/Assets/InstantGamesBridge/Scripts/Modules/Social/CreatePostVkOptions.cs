using System;

namespace InstantGamesBridge.Modules.Social
{
    [Serializable]
    public class CreatePostVkOptions : CreatePostPlatformDependedOptions
    {
        public string message;

        public string attachments;

        public CreatePostVkOptions(string message, string attachments)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
            this.message = message;
            this.attachments = attachments;
        }
    }
}