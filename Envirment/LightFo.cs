using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFo : MonoBehaviour {

	public GameObject GO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	transform.position = new Vector3(GO.transform.position.x,GO.transform.position.y,GO.transform.position.z-0.25f);	
	}

}
