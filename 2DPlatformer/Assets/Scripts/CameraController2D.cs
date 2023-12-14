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
        tempPos = player.position;
        y = tempPos.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        inpHor = Input.GetAxis("Horizontal");

        if (inpHor < 0 ) headingDir = -1;
        else if (inpHor > 0) headingDir = 1;

        tempPos = player.position + Vector3.right * headingDir;
        tempPos.y = y;
        tempPos.z = z;
        tempPos = tempPos + Vector3.right * inpHor * headingDistance;
        currentPos = Vector3.MoveTowards(currentPos, tempPos, Time.deltaTime * maxDelta);

        transform.position = currentPos;
    }
}
