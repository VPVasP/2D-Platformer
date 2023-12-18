using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
  
    private AudioSource aud; //refrence to the audiosource component
    [SerializeField] private AudioClip coinCollectSound; //audiocollectsound clip
    public GameObject coinEffect; //our coin effect
    void Start()
    {
        //if we dont have an audiosource we add one and get the component audiosource
        if (aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false; //we don't want it to play any sounds at the start
    }
    private void Update()
    {
        transform.Rotate(Vector2.up * 100* Time.deltaTime); //we rotate the coin around the y axis 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the colliding object has the "Player" tag
        if (collision.CompareTag("Player")) {
            //we destroy the coin after 3 seconds and play the collectcoin sound
            Destroy(this.gameObject,0.3f);
            aud.clip = coinCollectSound;
            aud.Play();
            //we instatiate the coin effect
            GameObject coinEffectClone= Instantiate(coinEffect, this.transform.position, Quaternion.identity);
            Destroy(coinEffectClone.gameObject, 0.3f);//destroy the coin effect clone to save memory
            //add coins and update the ui from currency manager and ui manager
            CurrencyManager.instance.AddCoins();
            UIManager.instance.UpdateCoinsUI();
        }


    }
}
