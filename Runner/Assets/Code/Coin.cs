using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Audio sound = FindObjectOfType<Audio>();
            sound.Effects(4);

            UI uI = FindObjectOfType<UI>();
            uI.CoinPlus();

            Destroy(gameObject);
        }
    }
}
