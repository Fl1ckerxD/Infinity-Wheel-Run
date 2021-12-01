using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public static int skin;
    private Audio sound;

    public Text textCoin;
    public GameObject[] skinPlayer;
    public GameObject[] counts;
    public GameObject[] buyButtons;
    public GameObject[] wearButtons;
    public GameObject[] selectedIcon;
    private void Start()
    {
        Wear(skin);
        sound = FindObjectOfType<Audio>();

        int coins = PlayerPrefs.GetInt("Coins", 0);
        textCoin.text = coins.ToString();
    }
    public void Buy(int i)
    {
        if (UI.coins >= 15)
        {
            buyButtons[i].SetActive(false);
            counts[i].SetActive(false);
            wearButtons[i].SetActive(true);
            sound.Effects(5);
            CoinMinus(15);
            GetComponent<SaveAndLoad>().SaveGame();
        }
    }
    public void Wear(int color)
    {
        for (int i = 0; i < skinPlayer.Length; i++)
        {
            skinPlayer[i].SetActive(false);
            selectedIcon[i].SetActive(false);
        }
        skinPlayer[color].SetActive(true);
        selectedIcon[color].SetActive(true);
        skin = color;
    }
  
    private void CoinMinus(int i)
    {
        UI.coins -= i;
        textCoin.text = UI.coins.ToString();
        PlayerPrefs.SetInt("Coins", UI.coins);
    }
    public void ActiveButtons()
    {
        for (int i = 0; i < wearButtons.Length; i++)
        {
            if (buyButtons[i].activeSelf == false)
            {
                wearButtons[i].SetActive(true);
                counts[i].SetActive(false);
            }
        }
    }
}
