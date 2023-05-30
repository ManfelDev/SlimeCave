using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    private Transform  target;

    [SerializeField] private float      speed = 100;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            GameObject slime = GameObject.Find("Slime");
            if (slime == null)
            {
                return;
            }
            target = slime.transform;
        }

        Vector3 cameraPosition = transform.position;
        cameraPosition.y += 8f;
        transform.position = cameraPosition;

        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;

        Vector3 error = targetPosition - transform.position;

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = transform.position + error * Mathf.Min(Time.fixedDeltaTime / speed, 1);
    }
}
