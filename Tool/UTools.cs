using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTools {


	public Vector2 Direction2D(GameObject target) // return the direction
	{
		Vector2 dirX;
		dirX = new Vector2 (target.transform.localScale.x, 0);
		return dirX;
	}


	public int SmoothInput(float num) {
		if (num>0)
		{
			return 1;
		}
		else if (num < 0){
			return -1;
		}
		return 0;
	}



	public int FreezeAttack(GameObject playerObj){
		int num = 0;
		if (playerObj.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("JumpAttack")) {
			num++;
		}
		if (playerObj.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Hurt")) {
			//num++;
		}
		return num;
	}


	public Vector2 EnemyFilp2D(Vector3 target, GameObject EnemyGO){
		Vector2 Targetdir = Vector2.zero;
		if (target.x - EnemyGO.transform.position.x < 0) {
			EnemyGO.transform.localScale = new Vector3(-1,1,1);
			Targetdir = Vector2.left;
		} else {
			EnemyGO.transform.localScale = new Vector3(1,1,1);
			Targetdir = Vector2.right;
		}
		return Targetdir;
	}
}
