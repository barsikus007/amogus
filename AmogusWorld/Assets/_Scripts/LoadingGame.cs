using InstantGamesBridge;
using InstantGamesBridge.Modules.Player;
using UnityEngine;

public class LoadingGame : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Hello AmogusWorld!");
        Bridge.Initialize(isInitialized =>
        {
            if (isInitialized)
            {
                Debug.Log(Bridge.platform.id);
                Debug.Log($"isAuthorizationSupported {Bridge.player.isAuthorizationSupported}");
                Debug.Log($"isAuthorized {Bridge.player.isAuthorized}");

                // Debug.Log("Данные игрока");
                // Если игрок авторизован
                // Debug.Log(Bridge.player.id); // ID игрока
                // Если игрок авторизован (и отдельно для Yandex: если разрешил доступ к данной информации)
                // Debug.Log(Bridge.player.name); // Имя игрока
                // Debug.Log(Bridge.player.photos); // Список фотографий, отсортированных в порядке возростания размера
                // foreach (var photo in Bridge.player.photos)
                // {
                //     Debug.Log(photo);
                // }
                // Если авторизация поддерживается и игрок не авторизован - можно вызвать метод авторизации
                var yandexScopes = true; // Запрашивать доступ к имени и фото, по умолчанию = true
                var authorizeYandexOptions = new AuthorizeYandexOptions(yandexScopes); // Необязательный параметр
                Bridge.player.Authorize(
                    success =>
                    {
                        if (success)
                        {
                            Debug.Log("Авторизация прошла успешно");
                            // Теперь игрок авторизован
                            // Debug.Log(Bridge.player.name);
                            // foreach (var photo in Bridge.player.photos)
                            // {
                            //     Debug.Log(photo);
                            // }
                        }
                        else
                        {
                            Debug.Log("Авторизация отменена");
                            // Игрок не захотел авторизовываться, либо произошла ошибка 
                        }
                        UserData.InitData();
                    },
                    authorizeYandexOptions);
            }
            else
            {
                Debug.Log("Ошибка. Что-то пошло не так.");
                Application.Quit();
            }
        });
    }
}