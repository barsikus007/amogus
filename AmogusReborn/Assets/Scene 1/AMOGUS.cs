using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMOGUS : MonoBehaviour
{
    public Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null) 
        {
            GameObject player = GameObject.Find("Игрок");
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }

    // Срабатывает при столкновении с другим физ. объектом
    void OnTriggerEnter(Collider other)
    {
        // Пытаемся найти компонент игрока у объекта с которым столкнулись
        Player player = other.GetComponent<Player>();

        // Если у объекта есть такой компонент
        if (player != null) 
        {
            // Наносим Игроку урон
            player.TakeDamage(false);
        }
    }
}
