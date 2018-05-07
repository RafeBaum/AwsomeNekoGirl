using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool dest;
	Rigidbody enemyRB;
	Vector3 move;
	GameObject[] targetList;
	public float speed;
    float speedMod;
    float DissolveTime = 0.2f;
    GameController gc;
    Renderer rend;
  

	// Use this for initialization
	void Start() {
        dest = false;
		gc = GameObject.Find("GameController").GetComponent<GameController> ();

		targetList = GameObject.FindGameObjectsWithTag ("Finish");

		enemyRB = GetComponent<Rigidbody> ();
		move = targetList [Random.Range (0, 5)].transform.position - transform.position;

        rend = GetComponent<Renderer>();
	}

	void Update(){
		speedMod = speed + gc.points * 100;
        if (dest)
        {
            DissolveTime += Time.deltaTime;
            rend.material.SetFloat("_DissolveAmount", DissolveTime);
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
        if (col.gameObject.CompareTag("Bullet"))
        {
            dest = true;
            gc.PointCount(1);
            GetComponent<Collider>().enabled = false;
            Destroy(col.gameObject);
            Destroy(gameObject,2);
        }

    }
}
