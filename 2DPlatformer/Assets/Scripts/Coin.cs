using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
  
    private AudioSource aud;
    [SerializeField] private AudioClip coinCollectSound;
    public GameObject coinEffect;
    void Start()
    {
        if (aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }
    private void Update()
    {
        transform.Rotate(Vector2.up * 100* Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            Destroy(this.gameObject,0.3f);
            aud.clip = coinCollectSound;
            aud.Play();
            Instantiate(coinEffect, this.transform.position, Quaternion.identity);
            CurrencyManager.instance.AddCoins();
            UIManager.instance.UpdateCoinsUI();
        }


    }
}
