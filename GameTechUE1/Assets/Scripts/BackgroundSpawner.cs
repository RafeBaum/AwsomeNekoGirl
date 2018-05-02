using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

	Vector3 pos;
	float width = 2014f;
	public float speed;
	Vector3 move;
	float newZ;
	bool moved;
	public GameController gc;

	void Start(){
		move = new Vector3 (0f, 0f, -speed);
	}

	void Update(){
		if (!gc.end) {
			transform.position += move;
		}
	}

	void OnBecameInvisible(){
		if (!moved) {
			pos = gameObject.transform.position;
			newZ = pos.z + width * 2;

			gameObject.transform.position = new Vector3 (pos.x, pos.y, newZ);
			moved = true;
		}
	}
	void OnBecameVisible(){
		moved = false;

	}


}
