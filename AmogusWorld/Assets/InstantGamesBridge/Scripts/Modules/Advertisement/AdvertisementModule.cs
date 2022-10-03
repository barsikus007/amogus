#if UNITY_WEBGL
using System;
using UnityEngine;
#if !UNITY_EDITOR
using InstantGamesBridge.Common;
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Advertisement
{
    public class AdvertisementModule : MonoBehaviour
    {
        public event Action<InterstitialState> interstitialStateChanged;

        public event Action<RewardedState> rewardedStateChanged;

        public InterstitialState interstitialState { get; private set; }

        public RewardedState rewardedState { get; private set; }

        public int minimumDelayBetweenInterstitial
        {
            get
            {
#if !UNITY_EDITOR
                int.TryParse(InstantGamesBridgeMinimumDelayBetweenInterstitial(), out int value);
                return value;
#else
                return _minimumDelayBetweenInterstitial;
#endif
            }
        }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeMinimumDelayBetweenInterstitial();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeSetMinimumDelayBetweenInterstitial(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowInterstitial(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowRewarded();
#endif

        private Action<bool> _showInterstitialCallback;

        private Action<bool> _showRewardedCallback;

#if UNITY_EDITOR
        private int _minimumDelayBetweenInterstitial;

        private DateTime _lastInterstitialShownTimestamp = DateTime.MinValue;
#endif


        public void SetMinimumDelayBetweenInterstitial(int seconds)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeSetMinimumDelayBetweenInterstitial(seconds.ToString());
#else
            _minimumDelayBetweenInterstitial = seconds;
#endif
        }

        public void SetMinimumDelayBetweenInterstitial(SetMinimumDelayBetweenInterstitialPlatformDependedOptions firstPlatformDependedOptions, params SetMinimumDelayBetweenInterstitialPlatformDependedOptions[] otherPlatformDependedOptions)
        {
#if !UNITY_EDITOR
            var options = firstPlatformDependedOptions.ToJson();
            var other = otherPlatformDependedOptions.ToJson();
            if (!string.IsNullOrEmpty(other))
                options += ", " + other;

            InstantGamesBridgeSetMinimumDelayBetweenInterstitial(options.SurroundWithBraces().Fix());
#endif
        }

        public void ShowInterstitial(bool ignoreDelay = false, Action<bool> onComplete = null)
        {
            _showInterstitialCallback = onComplete;

#if !UNITY_EDITOR
            var json = ignoreDelay.ToString().SurroundWithKey("ignoreDelay").SurroundWithBraces().Fix();
            InstantGamesBridgeShowInterstitial(json);
#else
            var delta = DateTime.Now - _lastInterstitialShownTimestamp;
            if (delta.TotalSeconds > _minimumDelayBetweenInterstitial || ignoreDelay)
            {
                OnShowInterstitialCompleted("true");
                OnInterstitialStateChanged(InterstitialState.Opened.ToString());
                OnInterstitialStateChanged(InterstitialState.Closed.ToString());
            }
            else
            {
                OnShowInterstitialCompleted("false");
                OnInterstitialStateChanged(InterstitialState.Failed.ToString());
            }
#endif
        }

        public void ShowInterstitial(Action<bool> onComplete, ShowInterstitialPlatformDependedOptions firstPlatformDependedOptions, params ShowInterstitialPlatformDependedOptions[] otherPlatformDependedOptions)
        {
            _showInterstitialCallback = onComplete;
            ShowInterstitial(firstPlatformDependedOptions, otherPlatformDependedOptions);
        }

        public void ShowInterstitial(ShowInterstitialPlatformDependedOptions firstPlatformDependedOptions, params ShowInterstitialPlatformDependedOptions[] otherPlatformDependedOptions)
        {
#if !UNITY_EDITOR
            var options = firstPlatformDependedOptions.ToJson();
            var other = otherPlatformDependedOptions.ToJson();
            if (!string.IsNullOrEmpty(other))
                options += ", " + other;

            InstantGamesBridgeShowInterstitial(options.SurroundWithBraces().Fix());
#else
            OnShowInterstitialCompleted("true");
            OnInterstitialStateChanged(InterstitialState.Opened.ToString());
            OnInterstitialStateChanged(InterstitialState.Closed.ToString());
#endif
        }

        public void ShowRewarded(Action<bool> onComplete = null)
        {
            _showRewardedCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeShowRewarded();
#else
            OnShowRewardedCompleted("true");
            OnRewardedStateChanged(RewardedState.Opened.ToString());
            OnRewardedStateChanged(RewardedState.Rewarded.ToString());
            OnRewardedStateChanged(RewardedState.Closed.ToString());
#endif
        }


        // Called from JS
        private void OnShowInterstitialCompleted(string result)
        {
            var isSuccess = result == "true";

#if UNITY_EDITOR
            if (isSuccess)
                _lastInterstitialShownTimestamp = DateTime.Now;
#endif

            _showInterstitialCallback?.Invoke(isSuccess);
            _showInterstitialCallback = null;
        }

        private void OnShowRewardedCompleted(string result)
        {
            var isSuccess = result == "true";
            _showRewardedCallback?.Invoke(isSuccess);
            _showRewardedCallback = null;
        }

        private void OnInterstitialStateChanged(string value)
        {
            if (Enum.TryParse<InterstitialState>(value, true, out var state))
            {
                interstitialState = state;
                interstitialStateChanged?.Invoke(interstitialState);
            }
        }

        private void OnRewardedStateChanged(string value)
        {
            if (Enum.TryParse<RewardedState>(value, true, out var state))
            {
                rewardedState = state;
                rewardedStateChanged?.Invoke(rewardedState);
            }
        }
    }
}
#endif