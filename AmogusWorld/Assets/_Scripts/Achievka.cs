using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievka : MonoBehaviour
{
    public TextMeshProUGUI achievka;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            GameObject achievkas = GameObject.Find("Achievka");
            achievka = achievkas.GetComponent<TextMeshProUGUI>();
            if (UserData.achievments.Count != 0)
            {
                achievka.text = string.Join('\n', UserData.achievments);
            }

        }
    }
}
