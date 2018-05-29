using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ENEMYFSM{
	public class EnemyPatrol : EnemyFSMstate {
		UTools tools = new UTools();
	
		public EnemyPatrol(Transform[] wt){
			wayTransform = wt;
			actionID = EnemyAction.Patrol;
			curSpeed = 3.0f;
			chaseDistance = 7.0f;
			desPos = Vector3.zero;
		}

		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) > chaseDistance) {
				Debug.Log ("Patroling");
				EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
			}
		}

		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			Rigidbody2D rigi2d = EnemyGO.GetComponent<Rigidbody2D> ();
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) > chaseDistance) {
				Debug.Log ("Patrol Action");
				FindNextPoint ();
				rigi2d.velocity = tools.EnemyFilp2D (desPos,EnemyGO) * curSpeed; // turn to target
			}
		}

}
}
