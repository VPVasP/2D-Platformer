using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;
    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        boxCollider2d.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            collision.transform.position = CheckPointsManager.instance.checkPoints[0].transform.position;
            PlayerSoundManager.instance.PlayHurtSound();
        }
    }
}
