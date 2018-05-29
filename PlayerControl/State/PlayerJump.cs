using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PLCL{
	public class PlayerJump : PlayerState {
		public PlayerJump(GameObject Player){
			playerObj = Player;
		}

		public override void TransReason (GameObject Player)
		{
			return;
		}
		public override void Action ()
		{
			GameObject Jumpgo = playerObj.transform.GetChild(1).gameObject;
			if (Jumpgo.GetComponent<isGround> ().isJump) {
					playerObj.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 180f);
			}
		}
}
}
