using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Rigidbody enemyRB;
	Vector3 move;
	GameObject[] targetList;
	public float speed;
	GameController gc;

	// Use this for initialization
	void Start() {
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

		targetList = GameObject.FindGameObjectsWithTag ("Finish");

		enemyRB = GetComponent<Rigidbody> ();
		move = targetList [Random.Range (0, 3)].transform.position - transform.position;

		
	}

	void Update(){
		if (Vector3.Distance (targetList[0].transform.position, transform.position) >= 2000) {
			Destroy (gameObject);
		}
	}
		

	void FixedUpdate(){
		enemyRB.AddForce (Vector3.Normalize (move) * speed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision col){
		if(col.gameObject.CompareTag("Player")){
			gc.TheEnd ();
			Destroy (gameObject);
		}
			
	}
}
