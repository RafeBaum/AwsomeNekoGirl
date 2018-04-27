using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGoesBoom : MonoBehaviour {
	public float bulletSpeed;
	Rigidbody bulletRB;
	Vector3 move = new Vector3(0f,0f,1f);
	Transform playerPos;
	GameController gc;

	void Start(){
		bulletRB = GetComponent<Rigidbody> ();

		gc = GameObject.Find("GameController").GetComponent<GameController> ();
	}

	void Update(){
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
		if (Vector3.Distance (playerPos.position, transform.position) >= 2000) {
			Destroy (gameObject);
		}
	}


	void FixedUpdate(){
		bulletRB.AddForce (move * bulletSpeed*Time.deltaTime);

	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.CompareTag("Enemy")) {
			gc.PointCount (1);
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}


}
