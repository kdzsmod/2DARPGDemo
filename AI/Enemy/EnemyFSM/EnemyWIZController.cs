using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWIZController : AdvanceEnemyFSM {
	private GameObject Player;
	private EnemyAction ActionID; // The ActionID is used by AdvanceEnemyFSM
	private Animator anim;
	private Rigidbody2D rigi2d;
	private Heath heath;
	[HideInInspector]
	public bool IsAttack = false;
	private bool isOpen = false;
	private ENEMYFSM.EnemyAttack attack = new ENEMYFSM.EnemyAttack ();
	//private ENEMYFSM.EnemyPatrol patrol = new ENEMYFSM.EnemyPatrol ();
	private ENEMYFSM.EnemyChase chase = new ENEMYFSM.EnemyChase ();
	private ENEMYFSM.EnemyIdle idle =new ENEMYFSM.EnemyIdle();
	private ENEMYFSM.EnemyDead dead = new ENEMYFSM.EnemyDead();
	private ENEMYFSM.EnemyBack back = new ENEMYFSM.EnemyBack ();
	private ENEMYFSM.EnemyHurt hurt = new ENEMYFSM.EnemyHurt();
	private ENEMYFSM.EnemyInAir inAir = new ENEMYFSM.EnemyInAir();
	private ENEMYFSM.EnemySkillCombo0 ESkillc0 = new ENEMYFSM.EnemySkillCombo0 ();


	protected override void EnemyFSMAwake ()
	{
		
	}


	protected override void EnemyFSMSrart ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		rigi2d = GetComponent<Rigidbody2D> ();
		heath = GetComponent<Heath> ();
	}

	protected override void EnemyFSMFixedUpdate ()
	{
		base.EnemyFSMFixedUpdate ();
	}

	protected override void EnemyFSMUpdate ()
	{
		SetAnimation ();
		//	patrol.Reason (Player, this.gameObject);
		//	patrol.Action (Player, this.gameObject);
		idle.Reason(Player,this.gameObject);
		chase.Reason (Player, this.gameObject);
		attack.Reason (Player, this.gameObject);
		ESkillc0.Reason (Player, this.gameObject);
		inAir.Reason(Player,this.gameObject);
		hurt.Reason (Player, this.gameObject);
		dead.Reason (Player, this.gameObject);

		//back.Reason (Player, this.gameObject);

	

		switch (ActionID) {
		case EnemyAction.Chase:
			chase.Action (Player, this.gameObject);
			break;
		case EnemyAction.Attack:
			attack.Action (Player, this.gameObject);
			break;
		case EnemyAction.Die:
			dead.Action (Player, this.gameObject);
			break;
		case EnemyAction.Back:
		//	back.Action (Player, this.gameObject);
			break;
		case EnemyAction.InAir:
			inAir.Action (Player, this.gameObject);
			break;
		case EnemyAction.Hurt:
			hurt.Action (Player, this.gameObject);
			break;
		case EnemyAction.SkillCombo0:
			ESkillc0.Action (Player, this.gameObject);
			break;
		}

		AttackOfWZ (this.gameObject);
		Debug.Log ("Action:" + ActionID);
	}
	public void setAnimator(EnemyAction action){
		// advance the Animator statement
		ActionID = action;
	}

	private void SetAnimation(){
		anim.SetBool ("IsAttack",IsAttack);
		anim.SetFloat ("AiHor", Mathf.Abs (rigi2d.velocity.x));
		anim.SetInteger ("HP",heath.HP);
	}

	private void AttackOfWZ(GameObject Enemy)
	{
		AnimatorStateInfo animinfo = anim.GetCurrentAnimatorStateInfo (0);
		if(isOpen)
		if (animinfo.normalizedTime>=0.7f&&animinfo.IsName("attack")) {
			LoadSource.Instance.CreateFireBall(Enemy);
			isOpen = false;
		}
		if (animinfo.IsName ("idle"))
			isOpen = true;
	}
	public override void CreateFireBall (GameObject Go)
	{
		
	}
}
