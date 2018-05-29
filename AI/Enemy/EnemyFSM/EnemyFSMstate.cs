using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ENEMYFSM{
public abstract class EnemyFSMstate {

		protected float curSpeed;
		protected float chaseDistance = 7;
		protected float attackDistance = 5;
		protected float backDistance = 2;
		protected Vector3 desPos; // target Position
		protected Transform[] wayTransform;
		protected float AttackSpeed;
		protected float BackSpeed;
		protected bool AllowAttack;
		// wait time
		protected float Ctime;
		protected int Hp;


		protected Dictionary<EnemyTrans,EnemyAction> map = new Dictionary<EnemyTrans, EnemyAction> (); // Save the Transition

		protected EnemyAction actionID;

		public EnemyAction ID{
			get
			{
				return actionID;
			}
		}
		public void AddTransition(EnemyTrans trans,EnemyAction actionID){
			if (map.ContainsKey (trans)) {
				Debug.Log ("failure,The Enemy Transition has existed! ");
				return;
			}
			map.Add (trans,actionID);
			Debug.Log ("Success,The Enemy Transition:"+trans+" has added!");
		}
		public void DelTransition(EnemyTrans trans,EnemyAction actionID){
			if (!map.ContainsKey (trans)) {
				Debug.Log ("failure,The Enemy Transition:"+trans+" has not existed! ");
				return;
			}
			map.Remove (trans);
			Debug.Log ("Success,The Enemy Transition has removed!");
		}

		public EnemyAction GetOutAction(EnemyTrans trans){
			return EnemyAction.Patrol;
		}

		public void FindNextPoint(){
			int rndIndex = Random.Range(0,wayTransform.Length);
			Vector3 rndPos = wayTransform [rndIndex].position;
			Vector3 rndPosition = Vector3.zero;
			desPos = rndPos + rndPosition;
		}

	public abstract void Reason (GameObject PlayerGO, GameObject EnemyGO);
	public abstract void Action (GameObject PlayerGO, GameObject EnemyGO);
}
}
