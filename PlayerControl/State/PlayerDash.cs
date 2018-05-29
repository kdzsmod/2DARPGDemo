using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace PLCL{
	public class PlayerDash : PlayerState
{
		UTools tools = new UTools();
		public PlayerDash (GameObject Player){
			IsDash = false;
			timelost = 0f;
			playerObj = Player;
		}

		public override void TransReason (GameObject Player)
		{
			return;
		}

		public override void Action ()
		{
			float hor = 0.0f;
				hor = Input.GetAxis ("Horizontal");
			if (OnButtonPressed.Instance.btnDClickDown.Contains (Ainput.btn0)) {
				IsDash = true;
			}
			//Vector2 QueckSpeed = new Vector2(5.5f*tools.SmoothInput(hor),playerObj.GetComponent<Rigidbody2D>().velocity.y);
			Vector2 QueckSpeed = new Vector2(5.5f*tools.Direction2D(playerObj).x,playerObj.GetComponent<Rigidbody2D>().velocity.y);
			if (IsDash) {
				if (playerObj.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("dash")) {
					playerObj.GetComponent<Rigidbody2D>().velocity = QueckSpeed;
					if (playerObj.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.70f) {
						IsDash = false;
					}
				} else if (tools.FreezeAttack (playerObj) > 0) {
					IsDash = false;
				}
			}

			if (Input.GetKeyDown(KeyCode.D)&&tools.FreezeAttack (playerObj) == 0)
			{

				if (Time.time - timelost <= 0.3f)///0.3秒之内按下有效  
				{
					if(Input.GetKeyDown(KeyCode.D))
						IsDash = true;

				}
				timelost = Time.time;
			}
			if (Input.GetKeyDown(KeyCode.A)&&tools.FreezeAttack (playerObj) == 0)
			{
				if (Time.time - timelost <= 0.3f)///0.3秒之内按下有效  
				{
					if(Input.GetKeyDown(KeyCode.A))
						IsDash = true;
				}
				timelost = Time.time;
			}



				}


}
}

