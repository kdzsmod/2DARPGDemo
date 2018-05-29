using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWizardController : MonoBehaviour {

	[HideInInspector]
	public Animator anim;
	[HideInInspector]
	public float speed = 1.5f;
	[HideInInspector]
	public Rigidbody2D rigi2d;
	public ScopeOfAttack Sat;
	public CheckDistance check;
	public PLCL.PlayerController Player;
	public isGround isground;
	public bool IsAttack;
	private Vector2 Targetdir;
	private GameObject Swordtemp;
	private GameObject Sword;
	private GameObject Fire;
	private bool isAllowAttack;


	// Use this for initialization
	void Start () {
		IsAttack = false;
		isAllowAttack = true;
		anim = this.GetComponent<Animator> ();
		rigi2d = this.GetComponent<Rigidbody2D> ();
		Sword = Resources.Load ("Enemy/Sword") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (isground.isJump) {
			WiazrdAimove ();
		//	WiazrdAttack ();
		}
	}

	void CreateSword()
	{
		Swordtemp = Instantiate (Sword);
		Swordtemp.transform.position = new Vector3(transform.position.x,transform.position.y+1.2f,0.0f);
	}

	void CreateFireBall(){
		Fire = Instantiate (Resources.Load ("Enemy/fire1")) as GameObject;
		Fire.transform.position = new Vector3 (transform.position.x+transform.localScale.x*0.3f, transform.position.y, 0.0f);
	}

	void WiazrdAttack(){
		if (Sat.collider2d != null && Sat.collider2d.attachedRigidbody.tag=="Player") {
			if (isAllowAttack) {
				isAllowAttack = false;
				if ((transform.position - Player.transform.position).sqrMagnitude >= 4) {
					System.Random rm = new System.Random ();
					switch (rm.Next (2)) {
					case 0:
						StartCoroutine (WiazrdAttackcombo_1 (1.5f));
						break;
					case 1:
						StartCoroutine (WiazrdAttackcombo_2 (1.3f));
						break;
					}
				} else {
					StartCoroutine (WiazrdAttackcombo_2 (1.3f));
				}
			}
		}
	}

	void Filp2D(){
		if (Player.transform.position.x - transform.position.x < 0) {
			transform.localScale = new Vector3(-1,1,1);
			Targetdir = Vector2.left;
		} else {
			transform.localScale = new Vector3(1,1,1);
			Targetdir = Vector2.right;
		}
	}

	void WiazrdAimove() // Wiazrd's movement                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
	{
		Filp2D ();
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("attack")&&!anim.GetCurrentAnimatorStateInfo(0).IsName("hurt")) {
			if ((transform.position - Player.transform.position).sqrMagnitude > 5.0f) {
				rigi2d.velocity = Targetdir * speed;
			} else if ((transform.position - Player.transform.position).sqrMagnitude < 0.5f) {
				rigi2d.velocity = -Targetdir * speed*0.3f;
			}
		}
	}

	IEnumerator WiazrdAttackcombo_1(float wait = 0){
		IsAttack = true; 
		StartCoroutine (Cooling (3.0f));
		yield return new WaitForSeconds (wait);
		IsAttack = false;
		CreateSword ();
	}

	IEnumerator WiazrdAttackcombo_2(float wait = 0){
		IsAttack = true;
		StartCoroutine (Cooling (3.0f));
		yield return new WaitForSeconds (wait);
		IsAttack = false;
		CreateFireBall ();
	}

	IEnumerator Cooling(float wait = 0){
		yield return new WaitForSeconds (wait);
		isAllowAttack = true;
	}
}
