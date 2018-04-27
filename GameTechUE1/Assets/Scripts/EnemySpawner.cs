using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour {
	float t;
	public float spawnRate;
	public GameObject enemy;
	//Transform[] spawnList;

	// Use this for initialization
	void Start () {
		t = 0;
		//spawnList = GetComponentsInChildren<Transform> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > t) {
			Instantiate (enemy, transform.position, transform.rotation);
			t += spawnRate;
		}
		
	}
}
