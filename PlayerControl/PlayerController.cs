using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PLCL{
public class PlayerController : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D Rigi2d;
	private GameObject Playerfoot;
	private PlayerRun playerRun;
	private PlayerDash playerDash;
	private PlayerJump playerJump;
		private PlayerAttackPhys AttackPhys;
	private AnimatorStateInfo AttackStat;
		private PlayerDead playerDead;
		[HideInInspector]
		public bool IsDash;

	// Use this for initialization
	void Start () {
		Playerfoot = gameObject.transform.GetChild (1).gameObject;
		anim = GetComponent<Animator> ();
		Rigi2d = GetComponent<Rigidbody2D> ();
		playerRun = new PlayerRun (1.5f,this.gameObject);
		playerDash = new PlayerDash (this.gameObject);
		playerJump = new PlayerJump (this.gameObject);
		playerDead = new PlayerDead (this.gameObject);
		AttackPhys = new PlayerAttackPhys (this.gameObject);
		
	}
	// Update is called once per frame
	void Update () {
			AttackStat = anim.GetCurrentAnimatorStateInfo (1);
			IsDash = playerDash.IsDash;
			// The nomal statement of Player
			if (AttackStat.IsName ("stay1")&&!anim.GetCurrentAnimatorStateInfo(0).IsName("JumpAttack")) {
				playerRun.Action ();
				if (Input.GetKeyDown (KeyCode.Space)||OnButtonPressed.Instance.btnDClickDown.Contains(Ainput.btn1))
					playerJump.Action ();
			} 
			AttackPhys.Action ();
			playerDash.Action ();
			playerDead.Action ();
		    SetAnimator ();

	}
	public void SetAnimator(){
		anim.SetFloat ("Hspeed",Mathf.Abs(Rigi2d.velocity.x));
		anim.SetBool ("IsJump", Playerfoot.GetComponent<isGround> ().isJump);
		anim.SetBool ("IsHurt", gameObject.GetComponent<Heath> ().IsHurt);
		anim.SetInteger ("HP", gameObject.GetComponent<Heath> ().HP);
			anim.SetBool ("IsDash", IsDash);

	}
		public string AttackTransReason(){
			string name = "allowAttack";
			if (!AttackStat.IsName ("stay1")) {
				name = "allowDash";
			}
			return name;
		}
}
}
