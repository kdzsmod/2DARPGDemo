using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {

    private Rigidbody2D enemyRigi2D;
    private Animator enemyAnim;
    private GameObject player;
    private bool isAttack = true;
	private bool attackE = true;
    private Collision2D collision;
	private float AngleE;
	public SwordAngle angle;
	// Use this for initialization
	void Start () {

	}
	void Awake(){
		enemyRigi2D = GetComponent<Rigidbody2D>();
		enemyAnim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");


	}
	
	// Update is called once per frame
	void Update () {

	}
    void FixedUpdate() 
    {
		Attack ();
       
    }

    void Attack() 
    {
		if (isAttack) {
			StartCoroutine (EnemyAttackCombo1 ());
		}
    }

    IEnumerator EnemyAttackCombo1()
    {
		yield return new WaitForSeconds(0.5f); // wait for 0.5 second.

		transform.rotation = Quaternion.SlerpUnclamped(transform.rotation,Quaternion.Euler(0.0f, 0.0f, angle.Angle),Time.deltaTime*100f);
        yield return new WaitForSeconds(0.6f);  // wait for 0.6 second.
        //  2. Downward and insert.
        enemyRigi2D.AddForce((-transform.up)*150f);
        isAttack = false;
		StartCoroutine (Disappear (2.0f));
    }

	IEnumerator resetStat(float resetTime)  // Reset the enemy stat
	{
		
		yield return new WaitForSeconds (resetTime);
		//enemyRigi2D.constraints = RigidbodyConstraints2D.None;
		transform.rotation = Quaternion.SlerpUnclamped (transform.rotation,new Quaternion(0,0,0,0),Time.smoothDeltaTime*30f);
		transform.position =Vector3.Lerp(transform.position,new Vector3(transform.position.x,player.transform.position.y+2f,0f),Time.smoothDeltaTime);
		isAttack = true;
	}
		
	IEnumerator Disappear(float wait = 0)
	{
		yield return new WaitForSeconds (wait);
		Destroy (this.gameObject);
	}


    void OnCollisionEnter2D(Collision2D collision2d)
    {
        collision = collision2d;
		if (collision2d.collider.gameObject.tag == "ground")
		{
			enemyRigi2D.simulated = false;
		}

    }


}
