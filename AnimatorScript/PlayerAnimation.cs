using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rigi2D;
    public isGround isground;
    public Heath playerHPStat;
	public Movement Playermovement;
	public Attack PlayerAttack;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		rigi2D = Playermovement.rigi2D;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Hspeed",Mathf.Abs(rigi2D.velocity.x));
        anim.SetBool("IsJump", isground.isJump);
        anim.SetBool("IsHurt",playerHPStat.IsHurt);
		anim.SetInteger ("HP",playerHPStat.HP);
		anim.SetBool ("IsDashAttack",PlayerAttack.IsDashAttack);
		anim.SetBool ("IsSkillStat", PlayerAttack.SkillStat);
	}
}
