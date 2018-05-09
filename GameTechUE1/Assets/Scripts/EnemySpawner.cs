using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour {
	float t;
	public float spawnRate;
	float spawnRateMod;
	public GameObject enemy;
	public GameController gc;

	// Use this for initialization
	void Start () {
		t = 0;
		spawnRateMod = 0;
		
		
	}
	
	// Update is called once per frame
	void Update () {

		spawnRateMod = spawnRate - (float)gc.points / 20;
		if (spawnRateMod <= 0.5f) 
			spawnRateMod = 0.5f;


		if (Time.time > t) {
			Instantiate (enemy, transform.position, enemy.transform.rotation);
			t += spawnRateMod;
		}
		
	}
}
