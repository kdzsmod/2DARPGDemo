using UnityEngine;
using System.Collections;
namespace PLCL{
	public class PlayerAttackPhys : PlayerState
{

		// This Class is used to Attack Physh.
		UTools tools = new UTools();
		public PlayerAttackPhys(GameObject go){
			playerObj = go;
		}




		public override void TransReason (GameObject Player)
		{
			return;
		}


		public override void Action ()
		{
			Animator anim = playerObj.GetComponent<Animator> ();
			AnimatorStateInfo animinfo_1 = anim.GetCurrentAnimatorStateInfo (1);
			AnimatorStateInfo animinfo_0 = anim.GetCurrentAnimatorStateInfo (0);

			if (animinfo_0.IsName ("JumpAttack")) {
				playerObj.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,playerObj.GetComponent<Rigidbody2D>().velocity.y);
			}
			if (animinfo_0.IsName ("dash")&&animinfo_0.normalizedTime<0.70f) {
				playerObj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			
			} else {
				playerObj.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			
			}

				
		}
}
}

