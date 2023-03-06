using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform otherTeleport;    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.enabled = false;
            other.transform.position = otherTeleport.position;
            other.enabled = true;
        }
    }
}
