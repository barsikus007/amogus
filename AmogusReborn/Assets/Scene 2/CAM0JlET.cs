using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM0JlET : MonoBehaviour
{
    public Animator CAM0JlETAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("CAM0JlET pressed");
        CAM0JlETAnim.enabled = true;
    }
}
