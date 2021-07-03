using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        //transform.position = target.position + offset;    
        if (target.transform.position.y > 5)
        { 
            transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        }
        if (target.transform.position.y < 5)
        {
            transform.position = new Vector3(transform.position.x, 2.97f, transform.position.z);
        }
        /*Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;*/
        //transform.LookAt(target);
    }
}
