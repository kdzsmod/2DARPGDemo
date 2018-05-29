using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConventionAnimator : MonoBehaviour {

	public AIWizardController aicller;
	public Heath HP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		aicller.anim.SetFloat ("AiHor",Mathf.Abs(aicller.rigi2d.velocity.x));
		//aicller.anim.SetBool ("IsAttack",aicller.IsAttack);
		aicller.anim.SetBool ("Ishurt", HP.IsHurt);
		aicller.anim.SetInteger ("HP", HP.HP);
	}
}
