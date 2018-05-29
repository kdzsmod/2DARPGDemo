using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ENEMYFSM{
	public class EnemyIdle : EnemyFSMstate {
		UTools tools = new UTools();
		public EnemyIdle(){
			actionID = EnemyAction.Idle;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			if (EnemyGO.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
			}
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			tools.EnemyFilp2D (PlayerGO.transform.position, EnemyGO);
		}
}
}
