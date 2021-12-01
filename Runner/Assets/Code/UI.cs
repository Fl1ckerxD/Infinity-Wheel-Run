using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private float score;
    public static int coins;

    public Text textScore;
    public Text textCoin;
    public GameObject b_pause;
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        textCoin.text = coins.ToString();
        textScore.text = "0";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score += Time.fixedDeltaTime + 1;
        textScore.text = score.ToString("F0");
    }
    public void CoinPlus()
    {
        coins++;
        textCoin.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }
    public void OffButtonPause()
    {
        b_pause.SetActive(false);
    }
}
