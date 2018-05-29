using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour {

	[HideInInspector]
	public Collider2D collider2d;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D c2d)
	{
		
		if (c2d.gameObject.tag == "Player")
		{
			collider2d = c2d;
		}

	}
	void OnTriggerEixt2D(Collider2D c2d)
	{
		
		if (c2d.gameObject.tag == "Player") {
			collider2d = null;
		}


	}

}
