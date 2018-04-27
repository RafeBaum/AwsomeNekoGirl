using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

	Vector3 pos;
	public float width;
	float newZ;
	bool moved;

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
