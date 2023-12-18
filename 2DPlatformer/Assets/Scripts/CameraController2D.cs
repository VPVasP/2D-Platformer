using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float maxDelta = 10;
    [SerializeField] float headingDistance = 2f;
    Vector3 currentPos;
    Vector3 tempPos;
    float y;
    float z;
    float inpHor;
    float headingDir = 1;

    // Start is called before the first frame update
    void Start()
    {
        //we find the player object that has the tag player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //we store the initial player position and set the initial y and z values
        tempPos = player.position;
        y = tempPos.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //we get the horizontal axis
        inpHor = Input.GetAxis("Horizontal");
        //we determine the direction based on the horizontal axis 
        if (inpHor < 0 ) headingDir = -1;
        else if (inpHor > 0) headingDir = 1;
        //we calculate the target position based on the player's position, heading direction, and the input
        tempPos = player.position + Vector3.right * headingDir;
        tempPos.y = y;
        tempPos.z = z;
        tempPos = tempPos + Vector3.right * inpHor * headingDistance;
        //we move towards the target
        currentPos = Vector3.MoveTowards(currentPos, tempPos, Time.deltaTime * maxDelta);

        transform.position = currentPos;
    }
}
