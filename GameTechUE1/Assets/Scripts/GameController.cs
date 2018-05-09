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

	// Use this for initialization
	void Start () {
		end = false;
		looseTxt.gameObject.SetActive (false);
		repeat.gameObject.SetActive (false);
		quit.gameObject.SetActive (false);
		
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
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
