using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothRotate : MonoBehaviour {
    int dir = 0;
    public float turningRate = 30f;
    // Rotation we should blend towards.
    private Quaternion _targetRotation = Quaternion.identity;
    // Call this when you want to turn the object smoothly.
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(angles);
    }

    private void Update()
    {
        // Turn towards our target rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (dir == 0)
            {
                SetBlendedEulerAngles(new Vector3(0, 45, 0));
                dir = 1;
            }
            else if (dir == 1)
            {
                SetBlendedEulerAngles(new Vector3(0, -45, 0));
                dir = 0;
            }

           
        }
    }

}
