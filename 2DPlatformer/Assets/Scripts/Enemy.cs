using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private int waypointIndex;
    [SerializeField] private bool reachedDestination;
    private Rigidbody rb;
    private BoxCollider2D boxCollder;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        rb = GetComponent<Rigidbody>();
        boxCollder = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(waypointIndex);
        if (!reachedDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                reachedDestination = true;
            }
           
        }
     
        else
        {
            if (waypointIndex == 0)
            {
                this.transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
            }
            if (waypointIndex == 1)
            {
                this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            waypointIndex = (waypointIndex + 1) % waypoints.Length; 
            reachedDestination = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.position = CheckPointsManager.instance.checkPoints[0].transform. position;
            PlayerSoundManager.instance.PlayHurtSound();
        }
      
    }
}
