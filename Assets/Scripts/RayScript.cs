using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    // Start is called before the first frame update
     
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0f, 1.5f, 0f), Vector3.left * 5, Color.green);
        if (Physics.Raycast(transform.position + new Vector3(0f, 1.5f, 0f), Vector3.left, out hit, 5))
        {
            Debug.Log(hit.collider.gameObject.tag.ToString());
            if (hit.collider.gameObject.tag == "Player")
            {
                Destroy(GetComponent<Rigidbody>()); 
                float distance= hit.distance;
            }
        }
    }
}
