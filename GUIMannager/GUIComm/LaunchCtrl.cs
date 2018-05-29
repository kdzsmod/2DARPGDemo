using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCtrl : SceneUIBase<LaunchCtrl> {

	protected override void UIAwake ()
	{
		GameObject obj = GuiResourceMRG.Instance.Load (GuiResourceMRG.ResourcesType.UIScens, "Launch",cache:true);
	}
}
