using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Tooltip("Скорость движения")]
    public float speed;

    [Tooltip("Цель к которой мы движемся")]
    public Transform target;

    void Update () {

        // Смещаемся к цели
        transform.position = 
            Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

        // Разворачиваем нашего бота лицом к цели
        transform.LookAt (target.position);
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