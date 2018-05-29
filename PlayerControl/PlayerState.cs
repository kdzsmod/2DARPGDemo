using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLCL
{
	public abstract class PlayerState {
		
		public abstract void TransReason (GameObject Player);
		public abstract void Action ();

		protected Vector2 dirX;

		protected Vector2 theScale = Vector2.right;

		public bool IsDash = false;

		protected bool facingright;

		protected bool IsDashTimer = false;

		protected float timelost = 0;  

		protected float m_speed = 3f;

		protected GameObject playerObj;
		protected float hor =0.0f;

		protected int Hp;
}
}
