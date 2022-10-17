using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InstantGamesBridge;

public class Menu : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("ClownScene");
    }

    public void Settings()
    {
        Volume.volume = 1f - Volume.volume;
        audioSource.volume = Volume.volume;
    }

    public void Adult()
    {
        Volume.pitch = 1.5f + (1.5f - Volume.pitch);
        audioSource.pitch = Volume.pitch;
    }

    public void Reset()
    {
        UserData.ResetData();
        SceneManager.LoadScene("_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Ad()
    {
        Debug.Log("Almi AD");
        Bridge.advertisement.ShowRewarded(success =>
        {
            if (success)
            {
                Debug.Log("Almi AD Success");
                // Success
            }
            else
            {
                // Error
            }
        });
    }

    public void Almi()
    {
        Debug.Log("Almi Buy not implemented by yandex");
        Debug.Log("ShowInterstitial AD instead");
        Bridge.advertisement.ShowInterstitial(
            false,
            success =>
            { 
                if (success)
                {
                    Debug.Log("AD Success");
                }
                else
                {
                    // Error
                }
            }   
        );
    }
}
