using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour {
	public int Max_HP;
    public int HP;  // Life
    public bool IsHurt = false;
    private int HP_lost;
	private LoadSource load;
	private GameObject graves;
	// Use this for initialization
	void Start () {
        HP_lost = HP;
		Max_HP = HP;
	}
	
	// Update is called once per frame
	void Update () {

		if (HP_lost > HP&&!IsHurt) 
        {
			IsHurt = true;
			HP_lost = HP;
			LoadSource.Instance.HurtEffect (this.gameObject);
			StartCoroutine (waitHurt ());
        }
        if (HP <= 0) 
        {
			IsHurt = false;
			StartCoroutine (ChangeStat(3.0f));
        }

	}

	IEnumerator ChangeStat(float wait = 0)
	{
		yield return new WaitForSeconds (wait);
		//graves = Instantiate (Resources.Load ("Graves/graves-shadow_13")) as GameObject;
		//graves.transform.position = transform.position;
		//Destroy (this.gameObject);
		yield return new WaitForSeconds (3.0f);
		Destroy (GameObject.FindGameObjectWithTag ("Game"));
		Destroy (GameObject.FindGameObjectWithTag ("CtrlUI"));
		GuiResourceMRG.Instance.Load (GuiResourceMRG.ResourcesType.UIScens, "Launch", true);
	}

	IEnumerator waitHurt(){
		yield return new WaitForSeconds(0.2f);
		IsHurt = false;

	}
}
