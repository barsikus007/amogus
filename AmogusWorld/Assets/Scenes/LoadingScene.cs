using InstantGamesBridge;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Hello AmogusWorld!");
        Bridge.Initialize(isInitialized =>
        {
            if (isInitialized)
            {
                Debug.Log(Bridge.platform.id);
                Debug.Log("Готово, можно продолжать. Например, загружать следующую сцену.");
            }
            else
            {
                Debug.Log("Ошибка. Что-то пошло не так.");
            }
        });
    }
}