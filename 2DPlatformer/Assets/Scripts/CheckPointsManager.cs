using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    public static CheckPointsManager instance;
    public Transform[] checkPoints; //our transform of waypoints
    public GameObject playerInstance; //our player gameobject
    private GameObject playerInstatiated; //our clone gameobject
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //we instatiate the player at the first checkpoint and disable his movement
        playerInstatiated = Instantiate(playerInstance, checkPoints[0].transform.position,Quaternion.identity);
        playerInstatiated.GetComponent<Controller>().enabled = false;
        //we enable his movement after 2 seconds 
        Invoke("EnableMovement", 2f);
    }
    //function to enable the player movement
    private void EnableMovement()
    {
        playerInstatiated.GetComponent<Controller>().enabled =true;
    }
}
