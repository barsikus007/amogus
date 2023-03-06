using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    public float speed;
    public float timeToDestroy;
    private float timer;
    // Update is called once per frame
    void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if(timer>timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
