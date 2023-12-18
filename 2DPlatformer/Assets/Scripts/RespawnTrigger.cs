using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private BoxCollider2D boxCollider2d; //refrence to our boxcollider 
    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>(); //we assign the component
        boxCollider2d.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            //we move the player to the checkpoint manager 0 array element and we play the hurt sound
            collision.transform.position = CheckPointsManager.instance.checkPoints[0].transform.position;
            PlayerSoundManager.instance.PlayHurtSound();
        }
    }
}
