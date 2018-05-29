using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firefly : MonoBehaviour {
	// Use this for initialization
	private Light fireflyN;
	private bool LightSwitch;
	private bool StartLight;
	void Start () {
		fireflyN = gameObject.GetComponent<Light> ();
		LightSwitch = false;
		StartLight = false;
		StartCoroutine (RandomStart());
	}

	// Update is called once per frame
	void Update () {
		if(StartLight)
		if (!LightSwitch) {
			fireflyN.intensity -= Time.deltaTime;
			if (fireflyN.intensity < 4)
				LightSwitch = true;
		} else if(LightSwitch){
			fireflyN.intensity += Time.deltaTime;
			if (fireflyN.intensity > 10)
				LightSwitch = false;
		}

}
	IEnumerator RandomStart()
	{
		//System.Random rm = new System.Random ();
		yield return new WaitForSeconds (Random.Range(0.0f,3.0f));
		StartLight = true;
	}
}
