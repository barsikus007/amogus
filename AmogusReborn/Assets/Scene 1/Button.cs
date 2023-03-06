using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator buttonAnim;
    public Animator doorAnim;
    void OnTriggerEnter (Collider other){
        Debug.Log("Button pressed");
        buttonAnim.enabled = true;
        doorAnim.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
