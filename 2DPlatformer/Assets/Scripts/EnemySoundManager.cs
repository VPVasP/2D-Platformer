using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    public static EnemySoundManager instance;
    private AudioSource aud;
    [SerializeField] private AudioClip enemyDeadSound;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        if (aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }
    public void PlayDeadSound()
    {
        aud.clip = enemyDeadSound;
        aud.Play();
    }
}
