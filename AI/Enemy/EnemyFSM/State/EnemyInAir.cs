using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ENEMYFSM{
	public class EnemyInAir :EnemyFSMstate {

		public EnemyInAir(){
			actionID = EnemyAction.InAir;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			if (!EnemyGO.transform.GetChild (3).GetComponent<isGround> ().isJump) {
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
			}
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
		}
	
}
}
