using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUS_exe : MonoBehaviour
{
    public static float bottomY = -30f;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY){
            Destroy(this.gameObject);
        }
    }
}
