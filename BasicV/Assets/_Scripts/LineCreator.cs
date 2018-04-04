using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

    public GameObject[] LineUnits;
    public Transform InstantiationPoint;
    // Use this for initialization
	void Start () {
        int color = ReturnANumber(0, 7);
        for (int i = 0; i <= ReturnANumber(3, 10); i++)
        {
            InstantiationPoint.Translate(0, 0, 1);
            Instantiate(LineUnits[color], InstantiationPoint.position, InstantiationPoint.rotation);
        }
    }
    public int ReturnANumber(int st,int end)
    {
        return Random.Range(st,end);
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(LineGen());
	}

    IEnumerator LineGen()
    {
        yield return new WaitForSeconds(.5f);
        int color = ReturnANumber(0, 3);
        int length = ReturnANumber(3, 15);
        for (int i=0;i<=length;i++)
        {
            
            Instantiate(LineUnits[color], InstantiationPoint.position, InstantiationPoint.rotation);
            InstantiationPoint.Translate(0, 0, 1);
        }
    }
}
