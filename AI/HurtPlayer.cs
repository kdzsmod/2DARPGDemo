using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator hurtPlayer(int way) 
	{
		player.GetComponent<Heath> ().HP--;
		yield return 0;


	}

	void OnCollisionEnter2D(Collision2D collision2d)
	{
		if (collision2d != null)
		{
			if (collision2d.collider.gameObject.tag == "Player") {
				StartCoroutine (hurtPlayer (0));
			}
		}

	}
}
