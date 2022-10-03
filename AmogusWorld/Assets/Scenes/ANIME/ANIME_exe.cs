using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIME_exe : MonoBehaviour
{
    public GameObject amogusPrefab;

    public float speed = 5;

    public float timeBetweenEggDrops = 1f;

    public float leftRightDistance = 20f;

    public float chanceDirection = 0.05f;

    private bool rotated = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropEgg", 2f);
    }
    void DropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(amogusPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftRightDistance){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance){
            speed = -Mathf.Abs(speed);
        }

        if (speed < 0 && !rotated) {
            transform.Rotate(0, 180, 0);
            rotated = true;
        }
        else if (speed > 0 && rotated) {
            transform.Rotate(0, 180, 0);
            rotated = false;
        }
    }

    private void FixedUpdate() {
        if (Random.value < chanceDirection){
            speed *= -1;
        }
    }
}
