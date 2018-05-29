using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class GuiResourceMRG:Singleton<GuiResourceMRG> {

	private Hashtable m_PrefabTable; 

	public GuiResourceMRG(){
	
		m_PrefabTable = new Hashtable ();
	}

	public enum ResourcesType
	{
		/// <summary>
		/// 开始窗口
		/// </summary>
		UIScens,
		/// <summary>
		/// 角色控制器
		/// </summary>
		UIwindow,
		/// <summary>
		/// 角色
		/// </summary>
		Role,
		/// <summary>
		/// 特效
		/// </summary>
		Effect,
		/// <summary>
		/// 环境
		/// </summary>
		Environment,
		game,
		EnemyFire,
		EnemySword,
		blood,
		DashSkillEffect
	}
	#region Load 加载资源
/// <summary>
/// Load the specified type, path and cache.
/// </summary>
/// <param name="type">Type.</param>
/// <param name="path">Path.</param>
/// <param name="cache">If set to <c>true</c> cache.</param>
	public GameObject Load(ResourcesType type,string path,bool cache = false){
		StringBuilder sbr = new StringBuilder ();
		GameObject obj = null;
		if (m_PrefabTable.Contains (path)) {
			Debug.Log ("Cache");
			obj = m_PrefabTable [path] as GameObject;
		} else {
			switch (type) {

			case ResourcesType.UIScens:
				sbr.Append ("GUI/Window/");
				break;
			case ResourcesType.UIwindow:
				sbr.Append ("GUI/ControlUI/");
				break;
			case ResourcesType.Effect:
				sbr.Append ("effect/");
				break;
			case ResourcesType.Role:
				sbr.Append ("Role/");
				break;
			case ResourcesType.Environment:
				sbr.Append ("Environment/");
				break;
			case ResourcesType.game:
				sbr.Append ("Game/");
				break;
			case ResourcesType.EnemyFire:
				sbr.Append ("Enemy/");
				break;
			case ResourcesType.EnemySword:
				sbr.Append ("Enemy/");
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
	#endregion

	#region Release 释放资源
	/// <summary>
	/// Release this instance.
	/// </summary>
	protected override void Release ()
	{
		m_PrefabTable.Clear ();
		Resources.UnloadUnusedAssets ();
	}
	#endregion
}
