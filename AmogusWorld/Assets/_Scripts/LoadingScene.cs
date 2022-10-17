using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Volume.volume;
        audioSource.time = Volume.time;
        audioSource.pitch = Volume.pitch;
        if (SceneManager.GetActiveScene().name == "_Menu")
        {
            UserData.RenderData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        Volume.volume = audioSource.volume;
        Volume.time = audioSource.time + 0.07f;
        Volume.pitch = audioSource.pitch;
    }
}
