using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aboba1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Cube") {
            Debug.Log("ENTER");
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.name == "Cube") {
            Debug.Log("EXIT");
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
