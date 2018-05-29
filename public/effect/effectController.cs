using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectController : MonoBehaviour {
	public float waittime = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (EffectDispear(waittime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator EffectDispear(float wait= 0){
	
		yield return new WaitForSeconds (wait);
		Destroy (this.gameObject);
	}
}
