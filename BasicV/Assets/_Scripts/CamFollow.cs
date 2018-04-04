using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private void Start()
    {
        offset=transform.position-target.position;
       
            
    }
    private void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, target.position));
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
    }
    void FixedUpdate()
    {
        
        if (Vector3.Distance(transform.position,target.position) >3.5f)
        {
            
        }
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        

    }
    private void LateUpdate()
    {
        transform.LookAt(target);
    }

}
