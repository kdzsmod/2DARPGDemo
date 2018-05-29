using UnityEngine;
using System.Collections;
namespace ENEMYFSM{
	public class EnemyDead : EnemyFSMstate
{
		public EnemyDead(){
			Hp = 10;
			actionID = EnemyAction.Die;
		}
		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			Hp = EnemyGO.GetComponent<Heath> ().HP;
			if (Hp == 0)
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator(actionID);
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			EnemyGO.GetComponent<Animator> ().Play ("die");
			EnemyGO.GetComponent<EnemyWIZController> ().enabled = false;
		} 
}
}

