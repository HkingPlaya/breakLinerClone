using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public Transform[] FireBarrelEnds;

    public Rigidbody bullet;
   
    private float dir = -1;
    private Rigidbody rocketInstance;
    public float force =1000f;
    
    public int barrelEndRandomizer()
    {
        return Random.Range(0, 6);
    }
    
    // Use this for initialization
	void Start () {
      //  barrelEnd = transform.GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            int val = barrelEndRandomizer();
            rocketInstance = Instantiate(bullet, FireBarrelEnds[val].position, FireBarrelEnds[val].rotation) as Rigidbody;
            if (FireBarrelEnds[val].CompareTag("oppo"))
            {
                rocketInstance.AddForce(Vector3.forward * force * dir);
            }
            else
                rocketInstance.AddForce(Vector3.forward * force);
        }
	}
}
