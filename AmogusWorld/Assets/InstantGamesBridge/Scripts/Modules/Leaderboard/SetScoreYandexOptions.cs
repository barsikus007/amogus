using System;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class SetScoreYandexOptions : SetScorePlatformDependedOptions
    {
        public int score;

        public string leaderboardName;

        public SetScoreYandexOptions(int score, string leaderboardName)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
            this.score = score;
            this.leaderboardName = leaderboardName;
        }
    }
}