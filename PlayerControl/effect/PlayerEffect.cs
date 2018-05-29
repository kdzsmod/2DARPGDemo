using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour {
	//public Movement movement;
	private bool BdashEffect;
	private GameObject DashEffect;
	private Animator anim;
	private PLCL.PlayerController playerCtro;
	// Use this for initialization
	void Start () {
		BdashEffect = true;
		anim = GetComponent<Animator> ();
		playerCtro = GetComponent<PLCL.PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("dash")&&BdashEffect) {
			BdashEffect = false;
			DashEffect = Instantiate (Resources.Load("effect/dashEffect")) as GameObject;
			Vector3 dashPositon = new Vector3 (transform.position.x - transform.localScale.x * 0.03f, transform.position.y - 0.05f, 0);
			DashEffect.transform.position = dashPositon;
			DashEffect.transform.localScale = transform.localScale;
			if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.1f)
			LoadSource.Instance.DashSkillE (gameObject);
		}
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("dash")) {
			BdashEffect = true;
		}
	}
}
