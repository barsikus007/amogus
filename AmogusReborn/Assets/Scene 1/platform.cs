using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    private bool isActive;
    void OnTriggerEnter (Collider other){
        if (other.gameObject.tag == "Stop"){
            direction = direction * -1;
        }
        if (other.gameObject.tag == "Player"){
            isActive = true;
        }
    }
    void OnTriggerExit (Collider other){
        if (other.gameObject.tag == "Player"){
            isActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
