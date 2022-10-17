using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public TextMeshProUGUI o4koText;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject o4koVal = GameObject.Find("Live");
            o4koText = o4koVal.GetComponent<TextMeshProUGUI>();
            if(!paused)
            {
                o4koText.text = "Пауза";
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                o4koText.text = "1 жизнь";
                Time.timeScale = 1;
                paused = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("_Menu");
        }
    }
}
