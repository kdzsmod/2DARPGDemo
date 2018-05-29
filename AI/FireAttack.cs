using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour {
	private GameObject ailer;
	private Vector2 dir;
	private GameObject explore_effect;
	// Use this for initialization
	void Start () {
		//ailer = GameObject.Find("Wiazrd");
		//ailer = transform.p
		StartCoroutine (Dispear(3.0f));
		//transform.localScale = ailer.transform.localScale;
		dir = new Vector2 (transform.localScale.x,0);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().AddForce (dir * 3f);
	}
	IEnumerator Dispear(float wait = 0){
		yield return new WaitForSeconds (wait);
		Destroy (this.gameObject);
	}
	void OnCollisionEnter2D(Collision2D collision2d)
	{
		if (collision2d!=null) {
			explore_effect = Instantiate (Resources.Load ("effect/explore_01")) as GameObject;
			explore_effect.transform.position = this.transform.position; 
			Destroy (this.gameObject);
		}

	}
}
