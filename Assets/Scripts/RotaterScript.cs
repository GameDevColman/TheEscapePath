using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterScript : MonoBehaviour
{
    private float delta_degree = 0.0f;
    void Start() { }
    void Update()
    {
        ShootRay();
    }
    void ShootRay()
    {
        Vector3 origin1 = transform.position;
        RaycastHit hit;
        transform.Rotate(0.0f, delta_degree, 0);
        Vector3 direction = transform.right;
        delta_degree += 0.1f * Time.deltaTime;
        Debug.DrawLine(transform.position, direction * 5, Color.green);
        if (Physics.Raycast(origin1, direction, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);

        }
    }
}