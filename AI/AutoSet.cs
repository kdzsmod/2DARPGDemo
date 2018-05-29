using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSet : MonoBehaviour {

    private GameObject goPlane;
    private GameObject plane;
	// Use this for initialization
	void Start () {
         //  Debug.Log(goPlane.transform.position.x);
        int i = 1;
        for (i = 1; i <= 4;i++ )
            AutoSetMethod(i);
        }
    void AutoSetMethod(int planeNum)
    {
        goPlane = GameObject.Find("plane_" + planeNum);
                if (planeNum % 2 != 0)
                {
                 plane = Instantiate(goPlane);
                 plane.transform.position = new Vector3(goPlane.transform.position.x + (0.57f), goPlane.transform.position.y - 0.43f, 0f);
                }
                else {
                    plane = Instantiate(goPlane);
                   plane.transform.position = new Vector3(goPlane.transform.position.x + (-0.57f), goPlane.transform.position.y - 0.43f, 0f);
                    }

         }
              
	// Update is called once per frame
	void Update () {
        
	}
}
