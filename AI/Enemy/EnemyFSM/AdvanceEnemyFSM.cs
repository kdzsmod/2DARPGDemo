using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyAction{
	Idle,
	Patrol,
	Seach,
	Attack,
	Chase,
	Die,
	Hurt,
	Back,
	InAir,
	/// <summary>
	/// quick back from Player and Attack it
	/// </summary>
	SkillCombo0,
	/// <summary>
	/// The skill combo1 is used to Launch abundant SWords.
	/// </summary>
	SkillCombo1
}
public enum EnemyTrans{
	Found,
	Dead,
	Hurt,
	Miss,
	Attacking,
	Seaching
}
public class AdvanceEnemyFSM : EnemyFSMBase {
	protected override void EnemyFSMUpdate ()
	{

	}


}



