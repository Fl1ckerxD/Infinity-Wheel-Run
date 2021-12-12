using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если объект вошел в коллайдер и у него тег "Player", то игрок проигрывает
        {
            Time.timeScale = 0f;
            other.GetComponent<PlayerController>().Dead();
            FindObjectOfType<UI>().OffButtonPause();
        }
    }
}
