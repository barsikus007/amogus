using System;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class GetScoreYandexOptions : GetScorePlatformDependedOptions
    {
        public string leaderboardName;

        public GetScoreYandexOptions(string leaderboardName)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
            this.leaderboardName = leaderboardName;
        }
    }
}