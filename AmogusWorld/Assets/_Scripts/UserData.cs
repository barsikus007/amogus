using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using TMPro;

public class UserData : MonoBehaviour
{
    public static TextMeshProUGUI bestScore;
    public static TextMeshProUGUI nameField;

    public static bool initialized = false;
    public static List<string> keys = new List<string>{"best_score", "achievments"};

    public static int score = 0;
    public static List<string> achievments = new List<string>();

    public static void ResetData()
    {
        score = 0;
        achievments = new List<string>();
        SaveData();
    }

    public static void RenderData()
    {
        GameObject name = GameObject.Find("Nickname");
        nameField = name.GetComponent<TextMeshProUGUI>();
        if (Bridge.player.name.Count() > 0){
            nameField.text = Bridge.player.name;
        }

        GameObject bestVal = GameObject.Find("Best");
        bestScore = bestVal.GetComponent<TextMeshProUGUI>();
        bestScore.text = "Лучший счёт: " + score; 
    }

    public static void InitData()
    {
        if (!initialized) {
            Bridge.advertisement.interstitialStateChanged += state => { Debug.Log($"Interstitial state: {state}"); };
            Bridge.advertisement.rewardedStateChanged += state => { Debug.Log($"Rewarded state: {state}"); };
            Debug.Log("InitData score achievments");
            Bridge.storage.Get(keys, (success, data) =>
                {
                    if (success)
                    {
                        Debug.Log($"ya.storage data {string.Join(';', data)}");
                        Debug.Log($"ya.storage score {data[0]}");
                        if (data[0] != null)
                        {
                            score = int.Parse(data[0]);
                        }
                        Debug.Log($"ya.storage achievments {data[1]}");
                        if (data[1] != null)
                        {
                            achievments = data[1].Split(';').ToList();
                        }
                        initialized = true;
                    }
                    else
                    {
                        // Ошибка
                    }
                    RenderData();
                });
        }
    }

    public static void SaveData()
    {
        Debug.Log($"SaveData score {score}");
        Debug.Log($"SaveData achievments<{achievments.Count()}> {string.Join(';', achievments)}");
        var values = new List<object>{score, string.Join(';', achievments)};
        // Сохранить данные по ключу
        Bridge.storage.Set(keys, values, success =>
        {
            if (success)
            {
                Debug.Log("score saved");
                // Готово, данные сохранены
            }
            else
            {
                // Ошибка сохранения
            }
        });
        
        Debug.Log($"SaveLeaderboard BiggestScore {score}");
        var yandexLeaderboardName = "BiggestScore";
        Bridge.leaderboard.SetScore(
            success =>
            {
                if (success)
                {
                    Debug.Log("BiggestScore saved");
                    // Success
                }
                else
                {
                    // Error
                }
            },
            new SetScoreYandexOptions(score, yandexLeaderboardName));
    }
}
