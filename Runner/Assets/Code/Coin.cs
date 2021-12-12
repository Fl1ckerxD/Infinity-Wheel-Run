using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если объект вошел в коллайдер и у него тег "Player", то подбирается монетка
        {
            Audio sound = FindObjectOfType<Audio>();
            sound.Effects(4);

            UI uI = FindObjectOfType<UI>();
            uI.CoinPlus();

            Destroy(gameObject);
        }
    }
}
