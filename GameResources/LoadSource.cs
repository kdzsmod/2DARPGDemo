using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LoadSource :Singleton<LoadSource> {

	private Hashtable m_PrefabTable;

	public LoadSource(){
		m_PrefabTable = new Hashtable ();

	}


	public GameObject LoadGameObj(GuiResourceMRG.ResourcesType type,string path,bool cache=false){
		StringBuilder sbr = new StringBuilder();
		GameObject obj = null;
		if (m_PrefabTable.Contains (path)) {
			obj = m_PrefabTable [path] as GameObject;
		} else {
			switch (type) {
			case GuiResourceMRG.ResourcesType.EnemyFire:
				sbr.Append ("Enemy/");
				break;
			case GuiResourceMRG.ResourcesType.Effect:
				sbr.Append ("effect/");
				break;
			case GuiResourceMRG.ResourcesType.EnemySword:
				sbr.Append("Enemy/");
				break;
			case GuiResourceMRG.ResourcesType.blood:
				sbr.Append ("effect/blood/");
				break;
			}
			sbr.Append (path);
			obj = Resources.Load (sbr.ToString ()) as GameObject;
			if (cache) {
				m_PrefabTable.Add (path, obj);
			}
		}
		Debug.Log (sbr.ToString ());
		return GameObject.Instantiate (obj);
	}


	public void CreateFireBall (GameObject Go)
	{
		GameObject Fire;
		Fire = LoadGameObj (GuiResourceMRG.ResourcesType.EnemyFire, "fire1", cache:true);
		Fire.transform.position = new Vector3 (Go.transform.position.x+Go.transform.localScale.x*0.3f, Go.transform.position.y, 0.0f);
		Fire.transform.localScale = Go.transform.localScale;
	}
	public void CreateSword (GameObject Go,float height=1.2f,float wt = 1.5f)
	{
		GameObject Sword;
		Sword = LoadGameObj (GuiResourceMRG.ResourcesType.EnemySword, "Sword", cache: true);
		Sword.transform.position = new Vector3 (Go.transform.position.x+Go.transform.localScale.x*0.3f*wt, Go.transform.position.y+height, 0.0f);
	}

	public void HurtEffect(GameObject Go){
	
		GameObject blood;
		blood = LoadGameObj (GuiResourceMRG.ResourcesType.blood, "blood", cache: true);
		blood.transform.parent = Go.transform;
		blood.transform.localPosition = Vector3.zero;
	}

	public void DashSkillE(GameObject Go){
		GameObject obj = LoadGameObj (GuiResourceMRG.ResourcesType.Effect, "DashEffect2", cache: true);
		obj.transform.position = Go.transform.position;
		obj.transform.localScale = -Go.transform.localScale;
		obj.transform.parent = Go.transform;
	}
}
