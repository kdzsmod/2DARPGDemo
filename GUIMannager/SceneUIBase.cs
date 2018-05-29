using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Ainput{
	Left,
	Right,
	btn0,
	btn1,
	btn2,
	btn3,
	Start,
	END,
	Null
}
public class SceneUIBase<T> : MonoBehaviour where T :MonoBehaviour {

	public static T Instance;

	void Awake(){
		Instance = this as T;
		UIAwake ();
	}


	protected virtual void UIAwake(){
	
	}

	protected virtual void UIUpdate(){
	
	}

	protected virtual void UIStart(){
	
	}

	// Use this for initialization
	void Start () {
		UIStart ();
	}
	
	// Update is called once per frame
	void Update () {
		UIUpdate ();
	}
	protected virtual IEnumerator ClickDownTime(Ainput aip0,float waitTime = 0.05f){
		yield return new WaitForSeconds (waitTime);
	//	OnButtonPressed.Instance.btnDClickDown.Remove (aip0);
	}
}
