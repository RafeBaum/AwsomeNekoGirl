using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour {
  
    void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag("Enemy")) {
			Destroy (col.gameObject);
		}

		if (col.gameObject.CompareTag("Bullet")) {
			Destroy (col.gameObject);
		}
	}
}
