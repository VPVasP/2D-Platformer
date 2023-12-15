using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
  
    private AudioSource aud;
    [SerializeField] private AudioClip coinCollectSound;
  
    void Start()
    {
        if (aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            Destroy(this.gameObject,0.3f);
            aud.clip = coinCollectSound;
            aud.Play();
            CurrencyManager.instance.AddCoins();
            UIManager.instance.UpdateCoinsUI();
        }


    }
}
