using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private float _score;
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

    // Увеличение очков
    void FixedUpdate()
    {
        _score += Time.fixedDeltaTime + 1;
        textScore.text = _score.ToString("F0");
    }

    // Увеличение денег
    public void CoinPlus()
    {
        coins++;
        textCoin.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    // Выключение кнопки "Пауза"
    public void OffButtonPause()
    {
        b_pause.SetActive(false);
    }
}
