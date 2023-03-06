using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOLDAT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject z = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject v = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
        z.transform.localScale = new Vector3(2, 2, 2);
        z.transform.position =   new Vector3(0, 3, 0);
        v.transform.localScale = new Vector3(4, 3, 1);
        v.transform.position =   new Vector3(0, 0.5f, 0);
        o.transform.localScale = new Vector3(2, 8, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
