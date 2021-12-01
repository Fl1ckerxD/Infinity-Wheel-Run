using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{  
    public GameObject PanelStore;
    public GameObject PanelPause;
    public GameObject player;
    private Audio audiocs;
    private void Start()
    {
        Time.timeScale = 1f;
        audiocs = FindObjectOfType<Audio>();
    }
    public void Play()
    {
        audiocs.Effects(0);
        LoadScreen.sceneID = 2;
        SceneManager.LoadScene(1);       
    }
    public void Restart()
    {
        audiocs.Effects(0);
        SceneManager.LoadScene(2);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        PanelPause.SetActive(false);
        player.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        PanelPause.SetActive(true);
        player.SetActive(false);
    }
    public void BackToMenu()
    {
        audiocs.Effects(1);
        LoadScreen.sceneID = 0;
        SceneManager.LoadScene(1);
    }
}
