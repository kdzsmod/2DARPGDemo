using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PLCL{
	public class PlayerRun : PlayerState {
		public PlayerRun(float runSpeed,GameObject Player){
			m_speed = runSpeed;
			theScale = Vector2.right;
			playerObj = Player;
		}
		public override void TransReason (GameObject Player)
		{
			return;
		}
		public override void Action ()
		{
			hor = 0;
			if (OnButtonPressed.Instance.btnPress.Contains (Ainput.Left)) {
				hor = -1;
			} else if(OnButtonPressed.Instance.btnPress.Contains (Ainput.Right)) {
				hor = 1;
			}
			if(OnButtonPressed.Instance.btnPress.Count==0)
			hor = Input.GetAxis ("Horizontal");
			if ((hor < 0 && !facingright) || (hor > 0 && facingright))
			{
				facingright = !facingright;
				theScale = playerObj.transform.localScale;
				playerObj.transform.localScale = new Vector3(-1*theScale.x,1,1);
			}
			Vector2 NomalSpeed = new Vector2(hor * m_speed, playerObj.GetComponent<Rigidbody2D>().velocity.y);
			playerObj.GetComponent<Rigidbody2D> ().velocity = NomalSpeed;
		}
}
}
