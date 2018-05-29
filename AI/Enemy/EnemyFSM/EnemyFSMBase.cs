using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSMBase : MonoBehaviour {


	protected virtual void EnemyFSMSrart(){}
	protected virtual void EnemyFSMUpdate(){}
	protected virtual void EnemyFSMFixedUpdate(){}
	protected virtual void EnemyFSMAwake(){}

	// Use this for initialization

	void Awake(){
		EnemyFSMAwake ();
	}

	void Start () {
		EnemyFSMSrart ();
	}
	
	// Update is called once per frame
	void Update () {
		EnemyFSMUpdate ();
	}

	void FixedUpdate(){
		EnemyFSMFixedUpdate ();

	}

	public virtual void CreateFireBall (GameObject Go)
	{
		
	}

	public virtual void CreateSword (GameObject Go)
	{
		
	}
		

	public virtual IEnumerator waitR(){
		yield return 0;
	
	}



}
