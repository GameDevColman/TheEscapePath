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
    public PlayerInventory playerInventory;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsSitting", false);
        animator.SetBool("IsWalking", true);
    }

    void Update()
    {       
        target = waypoints[currentWayPoint].position;
        moveDirection = target - transform.position;
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
        
        if (moveDirection.magnitude < 1 && flag)
        {
            currentWayPoint = ++currentWayPoint % waypoints.Length;
            StartCoroutine(Stay());
        }
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collider.gameObject.transform.parent.gameObject);
            playerInventory.DialogShow("Youv'e been defeated");
        }
    }

    IEnumerator Stay()
    {
        flag = false;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsSitting", true);
        yield return new WaitForSeconds(UnityEngine.Random.Range(3,7));
        animator.SetBool("IsSitting", false);
        animator.SetBool("IsWalking", true);
        GetComponent<Transform>().LookAt(waypoints[currentWayPoint]);
        flag = true;
    }
}
