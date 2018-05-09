using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public GameObject bulletSpawn,bullet;
	public KeyCode shootButton;
	public float speed, fireRate;
	public Animator anim;
		
	Rigidbody playerRB;
	float moveH,moveV;
	float nextBullet;
	Vector3 moveVec;
	bool end;


	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody> ();
	

	}
		
	
	// Update is called once per frame
	void Update () {
		if (!end) {
			
			moveH = Input.GetAxisRaw ("Horizontal");
			moveV = Input.GetAxisRaw ("Vertical");


			if (Input.GetKey (shootButton) && Time.time > nextBullet) {
				ShootShot ();
			}

		}
		
	}

	void FixedUpdate(){
		moveVec =  Vector3.Normalize( new Vector3 (-moveV, 0f, moveH));
		playerRB.AddForce (moveVec*speed);


	}


	void ShootShot(){
		nextBullet= Time.time + fireRate;
		anim.Play ("attack",-1,0.5f);
		Instantiate (bullet, bulletSpawn.transform.position, bullet.transform.rotation);
	}

	public void Death(){
		end = true;
		anim.Play ("die");
		playerRB.isKinematic = true;
		GetComponent<CapsuleCollider> ().enabled = false;

	}

	public void Respawn(){
		end = false;
		anim.Play ("idle");
		playerRB.isKinematic = false;
		GetComponent<CapsuleCollider> ().enabled = true;
	}


}
