using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Tooltip("Префаб снаряда")]
    public GameObject fireballPrefab;

    [Tooltip("Точка вылета снаряда")]
    public Transform attackPoint;

    [Tooltip("Количество монеток, которые собрал Игрок")]
    public int coins = 0;

    [Tooltip("Максимальное здоровье Игрока")]
    public int healthMax = 10;
    [Tooltip("Текущее здоровье Игрока")]
    public int health = 10;

    [Tooltip("Компонент, отвечающий за анимацию полчучения урона")]
    public Animator damageMaskAnimator;

    [Tooltip("Компонент, отвечающий за проигрывание звуков Игрока")]
    public AudioSource audioSource;
    [Tooltip("Звуковой файл звука получения урона")]
    public AudioClip damageSound;

    private bool spikeLock = false;

    void Update () {

        // Если игрок кликает левой кнопкой мыши
        // создать огненный шар
        if (Input.GetMouseButtonDown (0)) {
            Instantiate (fireballPrefab, attackPoint.position, attackPoint.rotation);
        }

    }

    // Обработка входного урона
    public void TakeDamage(bool frostDamage)
    {
        health--;
        float healthFloat = (float)health / healthMax;
        GameObject o4koVal = GameObject.Find("health");
        var o4koText = o4koVal.GetComponent<Slider>();
        o4koText.value = healthFloat;

        // Если здоровье все еще больше 0
        if (health > 0) 
        {
            damageMaskAnimator.enabled = true;
            // Проигрываем анимацию получения урона
            if (frostDamage) {
                damageMaskAnimator.SetTrigger("blinkBlue");
            } 
            else {
                // damageMaskAnimator.SetTrigger("blinkRed");
                damageMaskAnimator.Play("боль", -1, 0f);
            }

            // Проигрываем звук получения урона
            audioSource.PlayOneShot(damageSound);
        }
        // Если здоровье меньше или равно 0
        else 
        {
            // Перезагружаем текущую сцену
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void OnTriggerEnter(Collider other){
        // Если игрок врезался в монетку
        if (other.gameObject.tag == "Coin") {
            // Увеличиваем количество монеток
            coins++;
            GameObject o4koVal = GameObject.Find("coins");
            var o4koText = o4koVal.GetComponent<TextMeshProUGUI>();
            o4koText.text = coins.ToString("D8");
            // Уничтожаем монетку
            Destroy(other.gameObject);
        }
        if (!spikeLock && other.gameObject.tag == "Spikes") {
            spikeLock = true;
            this.TakeDamage(false);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Spikes") {
            spikeLock = false;
        }
    }
}
