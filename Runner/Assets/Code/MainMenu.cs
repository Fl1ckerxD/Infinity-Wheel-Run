using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{  
    /// <summary>
    /// Объекты сцены
    /// </summary>
    public GameObject PanelStore;
    public GameObject PanelPause;
    public GameObject player;
    private Audio _audio;
    private void Start()
    {
        Time.timeScale = 1f; // Стабилизация времени
        _audio = FindObjectOfType<Audio>(); // Кэширование аудио
    }

    // Запуск игровой сцены
    public void Play()
    {
        _audio.Effects(0);
        LoadScreen.sceneID = 2;
        SceneManager.LoadScene(1);       
    }

    // Перезагрузка игровой сцены
    public void Restart()
    {
        _audio.Effects(0);
        SceneManager.LoadScene(2);
    }

    // Продолжение игры
    public void Continue()
    {
        Time.timeScale = 1f;
        PanelPause.SetActive(false);
        player.SetActive(true);
    }

    // Пауза
    public void Pause()
    {
        Time.timeScale = 0f;
        PanelPause.SetActive(true);
        player.SetActive(false);
    }

    // Возвращение в главное меню 
    public void BackToMenu()
    {
        _audio.Effects(1);
        LoadScreen.sceneID = 0;
        SceneManager.LoadScene(1);
    }
}
