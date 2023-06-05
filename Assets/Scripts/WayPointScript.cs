using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public float speed = 5;
    int currentWayPoint;
    Vector3 target, moveDirection;
    private bool flag = true; 
    private Animator animator;

    private void Start()
    {
        // animator = GetComponent<Animator>();
        // animator.SetBool("IsSitting", false);
        // animator.SetBool("IsWalking", true);
    }

    void Update()
    {       
        target = waypoints[currentWayPoint].position;
        moveDirection = target - transform.position;

        // if (!animator.GetBool("IsSitting") && !animator.GetBool("IsWalking")) 
        // {
        //     animator.SetBool("IsWalking", true);
        // }
        if (moveDirection.magnitude < 1 && flag)
        {
            currentWayPoint = ++currentWayPoint % waypoints.Length;
            StartCoroutine(Stay());
              
        }
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
    }

    // private void OnCollisionEnter(Collision collision) 
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Stay()
    {
        flag = false;
        // animator.SetBool("IsWalking", false);
        // animator.SetBool("IsSitting", true);
        yield return new WaitForSeconds(5);
        // animator.SetBool("IsSitting", false);
        // animator.SetBool("IsWalking", true);
        flag = true;
    }
}
