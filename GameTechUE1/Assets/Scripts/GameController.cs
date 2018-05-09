using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int points;
	public bool end;
	public Text pointTxt, looseTxt;
	public Button repeat, quit;
	public playerControl pc;
	public GameObject player;
	Transform playerStartpos;

	// Use this for initialization
	void Start (){
		end = false;
		looseTxt.gameObject.SetActive (false);
		repeat.gameObject.SetActive (false);
		quit.gameObject.SetActive (false);
		playerStartpos = player.transform;
	}

	void Update(){
		repeat.onClick.AddListener (Repeat);
		quit.onClick.AddListener (Quit);
		UpdateUI();

	}


	public void PointCount(int increase){
		points += increase;
		UpdateUI();

	}

	void UpdateUI(){
		pointTxt.text = "Points: " + points;
		if (end) {
			looseTxt.gameObject.SetActive (true);
			repeat.gameObject.SetActive (true);
			quit.gameObject.SetActive (true);
		} else {
			looseTxt.gameObject.SetActive (false);
			repeat.gameObject.SetActive (false);
			quit.gameObject.SetActive (false);
		}
	}

	public void TheEnd(){
		end = true;
		pc.Death ();

		StartCoroutine(Delay());

	}

	IEnumerator Delay(){

		yield return new  WaitForSecondsRealtime (1);
		Time.timeScale = 0;
	}

	void Quit(){
		Application.Quit ();

	}

	void Repeat(){

		points = 0;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy")) {
			Destroy (go);
		}
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet")) {
			Destroy (go);
		}
			
		player.transform.position = playerStartpos.position;
		pc.Respawn();

		Time.timeScale = 1;
		end = false;
	}
}
