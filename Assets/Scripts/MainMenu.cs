using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс-прокладка для использования в обработчиках событий нажатия кнопок Play и Exit.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene("Game");
    public void Exit() => Application.Quit();

    //Ожидаем, когда же в Unity подвезут статику в обработчики
}
