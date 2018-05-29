using UnityEngine;
using System.Collections;

public class PlayerControllerBase : MonoBehaviour
{
	public virtual void PStart(){}
	public virtual void PUpdate(){}
	public virtual void PFixedUpdate(){}
	// Use this for initialization
	void Start ()
	{
		PStart ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		PUpdate ();
	}
	void FixedUpdate(){
		PFixedUpdate ();
	}
}

