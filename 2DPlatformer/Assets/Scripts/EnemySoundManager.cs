using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    public static EnemySoundManager instance;
    private AudioSource aud; //refrence to our audio source
    [SerializeField] private AudioClip enemyDeadSound; //our enemy dead sound refrence
    private void Awake()
    {
        instance = this;
    }
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
    // function that plays the dead sound
    public void PlayDeadSound()
    {
        aud.clip = enemyDeadSound;
        aud.Play();
    }
}
