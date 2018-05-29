using UnityEngine;
using System.Collections;
namespace ENEMYFSM{
	public class EnemyBack : EnemyFSMstate
{
		UTools tools = new UTools();
		public EnemyBack(){
			actionID = EnemyAction.Back;
			backDistance = 0.5f;
			curSpeed = 0.5f;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) <= backDistance)
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			EnemyGO.GetComponent<Rigidbody2D> ().velocity = - tools.EnemyFilp2D (PlayerGO.transform.position,EnemyGO) * curSpeed;
				
		}
}
}

