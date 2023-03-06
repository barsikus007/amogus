using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    [Range(1, 3)]

    [Tooltip("Во сколько раз увеличить скорость")]

    public float speedFactor = 2;
    void OnTriggerEnter (Collider other){

        //other.GetComponent<FirstPersonController>().m_RunSpeed = 20;

        other.GetComponent<FirstPersonController>().m_RunSpeed *= speedFactor;
    }
    void OnTriggerExit (Collider other){

        //other.GetComponent<FirstPersonController>().m_RunSpeed = 10;

        other.GetComponent<FirstPersonController>().m_RunSpeed /= speedFactor;
    }
}
