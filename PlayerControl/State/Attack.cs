using System;
using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	private UTools tools = new UTools();
	[HideInInspector]
	public bool IsDashAttack;
	[HideInInspector]
	public bool skllCooling = true;
	[HideInInspector]
	public bool SkillStat = false;
	[HideInInspector]
	public bool isAirAttack = false;
	private isGround isground;

	//private Movement Playermovement;
	private AttackCheck attack;
	private Collider2D c2d_player;
    private Animator animplayer;
    private Rigidbody2D rigi2d;
    private Vector2 dirX;


    private int AttackNum = 0;  
    private float time = 0;
    private float lostTime = 0.6f;


    private bool isOpen = false;
	private bool isHurt;
	private bool waitTime = false;

	private Vector2 Attackforce;

	private PLCL.PlayerController playerCtro;




	// Use this for initialization
	void Start () {
       // player = GameObject.FindGameObjectWithTag("Player");
		attack = transform.GetChild (0).gameObject.GetComponent<AttackCheck>();
        animplayer = GetComponent<Animator>();
		playerCtro = GetComponent<PLCL.PlayerController> ();
		isground = transform.GetChild (1).gameObject.GetComponent<isGround> ();
		rigi2d = gameObject.GetComponent<Rigidbody2D>();
        c2d_player = GetComponent<CapsuleCollider2D>();
		dirX = Vector2.zero;
		Attackforce = Vector2.zero;
	}
	// Update is called once per frame
	void FixedUpdate(){
		
	

	}

	void Update () {
		isHurt = this.gameObject.GetComponent<Heath> ().IsHurt;
		dirX = tools.Direction2D(this.gameObject);
		Attack_logic_Nomoal ();
	}

    void Attack_logic_Nomoal()  //  keyJ
    {
		AnimatorStateInfo animinfo = animplayer.GetCurrentAnimatorStateInfo(1);

		if (Input.GetKeyDown(KeyCode.J)||OnButtonPressed.Instance.btnDClickDown.Contains(Ainput.btn3)&&!playerCtro.IsDash && isground.isJump)
        {

			if (animinfo.IsTag("0")&&!animplayer.IsInTransition(0)) // combo1
            {  
				rigi2d.AddForce(dirX * 30f);
				AttackNum = 1;
				StartCoroutine(hurtEnemy(0.35f,0,1)); // delay 0.25s

            }
            else if (animinfo.IsTag("1") && animinfo.normalizedTime >= 0.6f) // combo2
            {  
				rigi2d.AddForce(dirX * 30f);
				AttackNum = 2;
			    StartCoroutine(hurtEnemy(0.15f,1,1));
                
            }
            else if (animinfo.IsTag("2") && animinfo.normalizedTime >= 0.6f) // combo3
            {  
				rigi2d.AddForce(dirX * 30f);
				AttackNum = 3;
				StartCoroutine(hurtEnemy(0.25f,1,1));
               
            }
            else if (animinfo.IsTag("3") && animinfo.normalizedTime >= 0.6f) // combo4
            {
				rigi2d.AddForce(dirX * 50f);
				AttackNum = 4;
				StartCoroutine(hurtEnemy(0.25f,2,2));
               
            }
            else if (animinfo.IsTag("4") && animinfo.normalizedTime >= 0.6f) // goback combo1
            {
				rigi2d.AddForce(dirX * 30f);
				AttackNum = 1;
				StartCoroutine(hurtEnemy(0.25f,0,1));
        
            }
        }
		if (Input.GetKeyDown(KeyCode.J)||OnButtonPressed.Instance.btnDClickDown.Contains(Ainput.btn3)&& !isground.isJump) {
			resetAttackState ();
			animplayer.Play ("JumpAttack");        // set animation
			StartCoroutine(hurtEnemy(0.25f,1));
		}

		Attack_logic_Skill();  // K




		if (!animinfo.IsTag("0") && animinfo.normalizedTime>2.2f||playerCtro.IsDash) // 2.2f
        {
			resetAttackState ();
        }
		animplayer.SetInteger("AttackNum", AttackNum); // Attack of Stat
    }

	void resetAttackState(){
			animplayer.Play("stay1");
			AttackNum = 0;

	}

	void Attack_logic_Skill(){ // K
		AnimatorStateInfo animinfo = animplayer.GetCurrentAnimatorStateInfo(1);
		// it will clube
		if (Input.GetKeyDown (KeyCode.K)||OnButtonPressed.Instance.btnDClickDown.Contains(Ainput.btn2) && skllCooling && !SkillStat) {
			waitTime = true;
			skllCooling = false;
			SkillStat = true;
				StartCoroutine (SkillCombo1 (0.20f, 0.25f, 3f)); // start time is 0.18s,and end time is 0.25s,that cooling is 3.0s
		}
	}



	IEnumerator hurtEnemy(float attack_time,int effect = 0,int hurt = 1)   // create Ienumerator according to the List count
	{
		AnimatorStateInfo animinfo = animplayer.GetCurrentAnimatorStateInfo(1);
		// According to time of animation
		// wait for enemy
		yield return new WaitForSeconds(attack_time);
		switch (effect) {
		case 0:   // physics for up
			{
				Attackforce = Vector2.up * 80f;
			}
			break;
		case 1: // physics for down
			{
				Attackforce = Vector2.down * 300f + dirX * 250f;
			}
			break;
		case 2: // physics for forward
			{
				Attackforce = dirX * 120f;
			}
			break;
		case 3:// pysics for up
			{
				Attackforce = Vector2.up * 250f; 
			}
			break;
		}

		for (int goNumber = 0; goNumber < attack.enenmyGoList.Count; goNumber++) {
			attack.enenmyGoList [goNumber].GetComponent<Heath> ().HP-=hurt;	
			attack.enenmyGoList [goNumber].GetComponent<Rigidbody2D> ().AddForce (Attackforce);
			Debug.Log("Enemy"+attack.enenmyGoList[goNumber].tag+" has been attacked");  
		}
			 
		}

	IEnumerator SkillCombo1(float startTime = 0,float endTime = 0,float cooling = 0){
		yield return new WaitForSeconds (startTime);
		animplayer.Play("stay1");
		AttackNum = 6;
		StartCoroutine (hurtEnemy(startTime,3));
		yield return new WaitForSeconds (endTime);
		rigi2d.AddForce (Vector2.up * 250f);
		yield return new WaitForSeconds (cooling);
		skllCooling = true;
		SkillStat = false;
	}


	IEnumerator waitForAnything(float wait= 0)
	{
		yield return new WaitForSeconds (wait);
		waitTime = false;
	}

}
