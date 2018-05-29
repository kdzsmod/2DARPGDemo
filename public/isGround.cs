using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour {
    [HideInInspector]
    public bool isJump;
	[HideInInspector]
	public GameObject go;

	// Use this for initialization
	void Start () {
		go = GameObject.Find (transform.parent.name);
	}
	
	// Update is called once per frame

	void OnCollisionStay2D(Collision2D c2d) 
    {
		if(c2d!=null)
		if (go.GetComponent<Rigidbody2D>().velocity.y==0) 
        {
            isJump = true;
        }
    
    }
	void OnCollisionExit2D(Collision2D c2d)
    {
		if (go.GetComponent<Rigidbody2D>().velocity.y!=0)
        {
            isJump = false;
        }
    
    }
    
}
