using UnityEngine;
using System.Collections;
namespace PLCL{
	public class PlayerDead : PlayerState
{
		public PlayerDead(GameObject PlayerGo){
			playerObj = PlayerGo;
		}

		public override void TransReason (GameObject Player)
		{
			
		}
		public override void Action ()
		{
			if (playerObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die")) {
				
				playerObj.GetComponent<PlayerController> ().enabled = false;
				playerObj.GetComponent<Attack> ().enabled = false;
				playerObj.GetComponent<Heath> ().enabled = false;
			}
		}
}
}

