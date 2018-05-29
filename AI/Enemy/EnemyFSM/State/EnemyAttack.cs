using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ENEMYFSM{
	public class EnemyAttack : EnemyFSMstate {
		UTools tools = new UTools();
		public EnemyAttack(){
			//curSpeed = 3.0f;
			attackDistance = 2.0f;
			actionID = EnemyAction.Attack;
			AttackSpeed = 1.0f;
			AllowAttack = false;
			Ctime = 0;
			backDistance = 0.5f;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			float distance = Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position);
			if (distance <= attackDistance) {
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
			}
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{

			tools.EnemyFilp2D (PlayerGO.transform.position,EnemyGO);
			Animator anim = EnemyGO.GetComponent<Animator> ();
			AnimatorStateInfo animinfo = anim.GetCurrentAnimatorStateInfo (0);
				Ctime += Time.deltaTime;
				if (Ctime >= AttackSpeed) {
					Ctime = 0;
					AttackSpeed += Time.deltaTime;
					AllowAttack = true;

				} else {
					AllowAttack = false;
				}
			EnemyGO.GetComponent<EnemyWIZController> ().IsAttack = AllowAttack;
		}
}
}
