using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float speed;
    Rigidbody rb;
    public float force=100;
    int dir = 0;

    
    public float turningRate = 30f;
    // Rotation we should blend towards.
    private Quaternion _targetRotation = Quaternion.identity;
    // Call this when you want to turn the object smoothly.
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(angles);
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
     //   rb.AddForce(transform.forward * force);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("force" + force);
        transform.Translate(transform.forward * speed * Time.deltaTime);
        
        transform.Translate(Input.GetAxis("Horizontal"),0,0);
        /*  if(Input.GetKeyDown(KeyCode.Space))  Turns abruptly
          {

              if (dir == 0)
              {
                  transform.eulerAngles = new Vector3(0, 60, 0);
                  dir = 1;
              }
              else if(dir == 1)
              {
                  transform.eulerAngles = new Vector3(0, -60, 0);
                  dir = 0;
              }*/
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (dir == 0)
            {
                SetBlendedEulerAngles(new Vector3(0, 60, 0));
                dir = 1;
            }
            else if (dir == 1)
            {
                SetBlendedEulerAngles(new Vector3(0, -60, 0));
                dir = 0;
            }
            StartCoroutine(Pathcorrector());

        }
        else
        {
            // transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
    }
    private void FixedUpdate()
    {
        
    }
    IEnumerator Pathcorrector()
    {
        rb.AddForce(Vector3.forward * force);
     
        yield return new WaitForSeconds(1f);

        rb.AddForce(-Vector3.forward * force);
        SetBlendedEulerAngles(new Vector3(0, 0, 0));
    }
}

