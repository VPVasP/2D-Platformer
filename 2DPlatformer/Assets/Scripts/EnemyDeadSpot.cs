using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeadSpot : MonoBehaviour
{
    private AudioSource aud;
 [SerializeField]   private AudioClip enemyDeadSound;
    public GameObject smokeEffect;
    private void Start()
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
    
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Controller>().Jump();
            EnemySoundManager.instance.PlayDeadSound();
            Instantiate(smokeEffect, this.transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
        
    }
}
