using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAngle : MonoBehaviour {
	private GameObject player;
	public float Angle;
	Vector2 o = Vector2.zero;
	// Use this for initialization

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		o = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
		Angle = Vector2.Angle(o,Vector2.down) * direction();
	}
	
	// Update is called once per frame
	int direction() // Judge the Player direction
	{
		int dirNum = 0;
		if (player.transform.position.x>transform.position.x) {
			dirNum = 1;
		} else 
		{
			dirNum = -1;
		}
		return dirNum;
	}
}
