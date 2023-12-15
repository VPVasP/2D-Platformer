using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    public static CheckPointsManager instance;
    public Transform[] checkPoints;
    public GameObject playerInstance;
    private GameObject playerInstatiated;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
   playerInstatiated =    Instantiate(playerInstance, checkPoints[0].transform.position,Quaternion.identity);
        playerInstatiated.GetComponent<Controller>().enabled = false;
        Invoke("EnableMovement", 2f);
    }
    private void EnableMovement()
    {
        playerInstatiated.GetComponent<Controller>().enabled =true;
    }
}
