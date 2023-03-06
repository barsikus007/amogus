using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject amogusPrefab;
    public AudioClip amogusAudio;
    public AudioSource amogusPlayer;
    // Start is called before the first frame update
    private float amogusDelay = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BossFight started");
        amogusPlayer.PlayOneShot(amogusAudio);
        for (int i = 0; i <= 100; i++)
        {
            GameObject amg = Instantiate<GameObject>(amogusPrefab);
            amg.transform.position += new Vector3(0, 0, amogusDelay);
            amogusDelay++;
        }
    }
}
