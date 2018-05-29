using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ENEMYFSM{
	public class EnemySkillCombo0 :EnemyFSMstate {
		private UTools tools = new UTools();
		public EnemySkillCombo0(){
			actionID = EnemyAction.SkillCombo0;
			Ctime = 0.0f;
			BackSpeed = 3.0f;
			backDistance = 0.5f;
		}
		#region
		/// <summary>
		/// Reason the specified PlayerGO and EnemyGO.
		/// </summary>
		/// <param name="PlayerGO">Player G.</param>
		/// <param name="EnemyGO">Enemy G.</param>
		public override void Reason (GameObject PlayerGO, GameObject EnemyGO)
		{
			
			if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < backDistance) {
				Ctime += Time.deltaTime;
				if (Ctime > BackSpeed) {
					EnemyGO.GetComponent<EnemyWIZController> ().setAnimator (actionID);
					BackSpeed += Ctime;
				}
			}
		}
		#endregion
		#region
		/// <summary>
		/// Enemy leave the Player
		/// </summary>
		/// <param name="PlayerGO">Player G.</param>
		/// <param name="EnemyGO">Enemy G.</param>
		public override void Action (GameObject PlayerGO, GameObject EnemyGO)
		{
			EnemyGO.GetComponent<Rigidbody2D> ().AddForce (-tools.EnemyFilp2D (PlayerGO.transform.position,EnemyGO) * 300f);
			LoadSource.Instance.CreateSword (EnemyGO, 3.5f,5f);
			LoadSource.Instance.CreateSword (EnemyGO,1.2f,8f);
		}
		#endregion

	 

}
}
