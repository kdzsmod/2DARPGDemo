using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private Transform CameraTrans;
    private Transform PlayerTrans;
	// Use this for initialization
	void Start () {
        CameraTrans = GetComponent<Transform>();
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate() {

		transform.position = new Vector3 (PlayerTrans.position.x,PlayerTrans.position.y,-0.57f);
    }
}
