using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRefl : MonoBehaviour {


	public Cubemap cubmap;
	private Camera cam;
	private Material curMat;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateChange",1,0.1f);
		curMat = GetComponent<Renderer> ().sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		cam.transform.rotation = Quaternion.identity;
		cam.RenderToCubemap (cubmap);
		Debug.Log (cam.RenderToCubemap (cubmap));
		curMat.SetTexture ("_Cubemap", cubmap);
	}
	void UpdateChange(){

	}
}
