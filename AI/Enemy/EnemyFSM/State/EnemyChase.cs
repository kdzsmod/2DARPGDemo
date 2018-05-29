using UnityEngine;
using System.Collections;
namespace ENEMYFSM{
	public class EnemyChase :EnemyFSMstate 
{
		UTools tools = new UTools();
		public EnemyChase(){
			chaseDistance = 7.0f;
			curSpeed = 1.5f;
			actionID = EnemyAction.Chase;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			float distance = Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position);
			if (distance<=chaseDistance) {
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
			}
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			
			Rigidbody2D rigi2d = EnemyGO.GetComponent<Rigidbody2D> ();
			rigi2d.velocity = tools.EnemyFilp2D (PlayerGO.transform.position, EnemyGO) * curSpeed;

		}


}
}

