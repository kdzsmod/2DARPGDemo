using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnButtonPressed :SceneUIBase<OnButtonPressed> {

	private float delay = 0.2f;

	private float lastIsDownTime;


	[HideInInspector]
	public List<Ainput> btnPress = new List<Ainput>();
	[HideInInspector]
	public List<Ainput> btnDClickDown = new List<Ainput>();

	private Ainput SaveD = Ainput.Null;

	protected override void UIAwake ()
	{
		base.UIAwake ();
		UIButton[] btnArr = GetComponentsInChildren<UIButton> (true);
		for (int i = 0; i < btnArr.Length; i++) {
			UIEventListener.Get (btnArr [i].gameObject).onClick = BtnClick;
			UIEventListener.Get (btnArr [i].gameObject).onPress = BtnPress; 
			UIEventListener.Get (btnArr [i].gameObject).onHover = BtnHover;
		}
	}

	private void BtnHover(GameObject obj,bool isState){

	}

	private void BtnPress(GameObject obj,bool isDown){
		Ainput aip = Ainput.Null;
		switch (obj.name) {
		case "btn0":
			aip = Ainput.btn0;
			break;
		case "btn1":
			aip = Ainput.btn1;
			break;
		case "btn2":
			aip = Ainput.btn2;
			break;
		case "btn3":
			aip = Ainput.btn3;
			break;
		case "SprConL":
			aip = Ainput.Left;
			break;
		case "SprConR":
			aip = Ainput.Right;
			break;

		}
		if (isDown) {
			if (!btnPress.Contains (aip))
				btnPress.Add (aip);
		} else {
			if (btnPress.Contains (aip))
				btnPress.Remove (aip);
		}

	}

	private void BtnClick(GameObject go){
		Ainput aip = Ainput.Null;
		switch (go.name) {
		case "btn0":
			aip = Ainput.btn0;
			break;
		case "btn1":
			aip = Ainput.btn1;
			break;
		case "btn2":
			aip = Ainput.btn2;
			break;
		case "btn3":
			aip = Ainput.btn3;
			break;
		case "SprConL":
			aip = Ainput.Left;
			break;
		case "SprConR":
			aip = Ainput.Right;
			break;
		}
		switch (go.name) {
		case "Start":
			GameObject.Destroy (gameObject);
			BtnTogame ();
			break;
		case "END":
			GameObject.Destroy (gameObject);
			BtnTogame (1);
			break;
		case "btn3":
			break;
		} 

		if (!btnDClickDown.Contains (aip)) {
			btnDClickDown.Add (aip);
			StartCoroutine (ClickDownTime (aip, 0.00001f));
		}

	}
		
	private void BtnTogame(int bread=0){
		if (bread == 0) {
			GameObject gameobj = GuiResourceMRG.Instance.Load (GuiResourceMRG.ResourcesType.game, "Game", true);
		} else if(bread==1) {
			GameObject gameobj = GuiResourceMRG.Instance.Load (GuiResourceMRG.ResourcesType.game, "Game1", true);
		}
		GameObject obj = GuiResourceMRG.Instance.Load (GuiResourceMRG.ResourcesType.UIwindow, "ControlUI", true);

	}
	protected override IEnumerator ClickDownTime (Ainput aip0, float waitTime = 0.05f)
	{
		yield return new WaitForEndOfFrame ();
		btnDClickDown.Remove (aip0);
	}
	protected override void UIUpdate ()
	{
		base.UIUpdate ();
			 
	}


}
