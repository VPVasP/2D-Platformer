using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager instance;
    private AudioSource aud;//our audio refrence
    [SerializeField] private AudioClip jumpSound; //player jump sound refrence
    [SerializeField] private AudioClip hurtSound;//player hurt sound refrence
    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        //if the audiosource hasnt been added add it and get the component
        if ( aud == null)
        {
            this.AddComponent<AudioSource>();
        }
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }
    //play the jump sound effect function
    public void JumpSoundEffect()
    {
        aud.clip = jumpSound;
        aud.Play();
    }
    //play the hurt sound effect function
    public void PlayHurtSound()
    {
        aud.clip = hurtSound;
        aud.Play();
    }
}
