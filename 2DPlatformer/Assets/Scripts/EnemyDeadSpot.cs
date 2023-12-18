using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeadSpot : MonoBehaviour
{
    private AudioSource aud;//refrence to our audiosource
    [SerializeField]  private AudioClip enemyDeadSound; //enemy dead sound refrence
    public GameObject smokeEffect;//smoke effect refrence
    private void Start()
    {
     //if the audiosource hasnt been added add it and get the component
        if (aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.CompareTag("Player"))
        {
            //if the player enters the trigger he jumps
            collision.GetComponent<Controller>().Jump();
            //the enemy sound manager plays the dead sound
            EnemySoundManager.instance.PlayDeadSound();
            //we instatiate the smoke effect clone and destroy the enemy and the smoke effect clone after a few miliseconds
            GameObject smokeEffectClone=Instantiate(smokeEffect, this.transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject,0.3f);
            Destroy(smokeEffectClone, 0.2f);
        }
        
    }
}
