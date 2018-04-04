using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float speed;
    Rigidbody rb;
    public float force;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //  transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal"),0,0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.eulerAngles = new Vector3(0, 45, 0);
            rb.AddForce(Vector3.forward*force);
        }
    }
    private void OnMouseDown()
    {
        
    }
}
