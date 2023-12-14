using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager instance;
    private AudioSource aud;
    [SerializeField] private AudioClip jumpSound;
    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        if( aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }
    public void JumpSoundEffect()
    {
        aud.clip = jumpSound;
        aud.Play();
    }
}
