using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // our array of waypoints 
    [SerializeField] private float moveSpeed = 5f;//our move speed value
    private int waypointIndex; //the waypoint index
    [SerializeField] private bool reachedDestination; //bool to check if enemy has reached the destination
    private Rigidbody2D rb; //refrtence to the rigibody component
    private BoxCollider2D boxCollder; //refrence to the box collider component
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0; //we set the waypoint index to 0 at the start
        rb = GetComponent<Rigidbody2D>(); //get the rigibody component
        boxCollder = GetComponent<BoxCollider2D>(); //get the box collider component
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(waypointIndex);
        if (!reachedDestination)
        {
            //we move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);
            //check if the enemy has reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                reachedDestination = true;
            }
           
        }
     
        else
        {
            //rotate the enemy based on the waypoint index
            if (waypointIndex == 0)
            {
                this.transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
            }
            if (waypointIndex == 1)
            {
                this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            waypointIndex = (waypointIndex + 1) % waypoints.Length; //we move to the next waypoint
            reachedDestination = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //we teleport the player to the first checkpoint from the checkpoints manager
            collision.transform.position = CheckPointsManager.instance.checkPoints[0].transform. position;
            PlayerSoundManager.instance.PlayHurtSound();//we play a hurt sound of the coins manager
            rb.constraints = RigidbodyConstraints2D.FreezePosition; //we freeze the constrains of the rigibody
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;//we unfreeze the constrains of the rigibody
        }
      
    }
}
