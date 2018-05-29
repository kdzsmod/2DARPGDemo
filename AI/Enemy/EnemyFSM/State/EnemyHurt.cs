using UnityEngine;
using System.Collections;
namespace ENEMYFSM{
	public class EnemyHurt : EnemyFSMstate
{
		public EnemyHurt(){
			actionID = EnemyAction.Hurt;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			if (EnemyGO.GetComponent<Heath> ().IsHurt)
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			
		}

}
}

