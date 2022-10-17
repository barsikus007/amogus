using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InstantGamesBridge;
using TMPro;

public class SUCKER_CONTROL_exe : MonoBehaviour
{
    public static TextMeshProUGUI o4koText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject o4koVal = GameObject.Find("DimO4ka");
        o4koText = o4koVal.GetComponent<TextMeshProUGUI>();
        o4koText.text = "очко 0 в";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision call)
    {
        GameObject collided = call.gameObject;
        if (collided.tag == "IMPOSTER")
        {
            Destroy(collided);
        }
        int o4ku = int.Parse(o4koText.text.Substring(5, o4koText.text.Length - 7));
        if (o4ku % 10 == 9){
            ANIME_exe.speed *= 1.2f;
            ANIME_exe.timeBetweenEggDrops *= .9f;
        }
        o4ku++;
        o4koText.text = "очко " + o4ku.ToString() + " в";
    }

    public static void EndGame()
    {
        GameObject[] susArray = GameObject.FindGameObjectsWithTag("IMPOSTER");
        foreach(GameObject sus in susArray){
            Destroy(sus);
        }
        GameObject o4koVal = GameObject.Find("DimO4ka");
        o4koText = o4koVal.GetComponent<TextMeshProUGUI>();
        int o4ku = int.Parse(o4koText.text.Substring(5, o4koText.text.Length - 7));
        bool save = false;
        if (UserData.score < o4ku)
        {
            UserData.score = o4ku;
            save = true;
        }
        if (o4ku == 0 && !UserData.achievments.Contains("Новичок"))
        {
            UserData.achievments.Add("Новичок");
            save = true;
        }
        if (o4ku == 42 && !UserData.achievments.Contains("Смысл жизни"))
        {
            UserData.achievments.Add("Смысл жизни");
            save = true;
        }
        if (o4ku >= 228 && !UserData.achievments.Contains("Читак"))
        {
            UserData.achievments.Add("Читак");
            save = true;
        }
        
        if (save)
        {
            UserData.SaveData();
        }
        ANIME_exe.speed = 5;
        ANIME_exe.timeBetweenEggDrops = 1;
        Debug.Log("AD ShowInterstitial");
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
        SceneManager.LoadScene("_Menu");
    }
}
