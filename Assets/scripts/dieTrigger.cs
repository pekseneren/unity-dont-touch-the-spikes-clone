using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class dieTrigger : MonoBehaviour {

	public GameObject obj;
	public List<GameObject> gameOver = new List<GameObject>();
	public Animator animator;
	public Text score;
	public Text bestScore;
	public Text candyScore;
	public Text gameplayed;
	public Animator bestScoreAnimator;
	public Animator gamePlayedAnimator;
	public Animator candyScoreAnimator;

	void Start(){

		gameplayed.text = PlayerPrefs.GetInt ("GamePlayed").ToString ();
		candyScore.text = PlayerPrefs.GetInt ("CandyScore").ToString ();
		bestScore.text = PlayerPrefs.GetInt ("HighScore").ToString();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {

			gameOver.Clear ();

			score.text = obj.GetComponent<birdy> ().scriptText.text;
			scoreSave(Int32.Parse (score.text), obj.GetComponent<birdy>().sekerSkoru);

			obj.GetComponent<birdy> ().scriptText.text = "";
			Destroy (obj);
			Destroy (GameObject.FindGameObjectWithTag ("seker"));

			animator.SetTrigger ("trigger");

			loadScore ();
			bestScoreAnimator.ResetTrigger ("trigger");
			gamePlayedAnimator.ResetTrigger ("trigger");
			candyScoreAnimator.ResetTrigger ("trigger");

			//sceneLoader scene = GameObject.Find ("sceneManager").GetComponent<sceneLoader> ();
			//sprt.transform.position = new Vector3(sprt.transform.position.x,sprt.transform.position.y,GameObject.FindGameObjectWithTag("spawnController").transform.position.z-1);
			//replay.GetComponent<Button> ().onClick.AddListener (scene.sceneLoad);
		}
	}

	public void scoreSave(int newScore, int candyScore){

		int tempGamePlayed = PlayerPrefs.GetInt ("GamePlayed");
		tempGamePlayed++;
		PlayerPrefs.SetInt ("GamePlayed", tempGamePlayed);
		int tempCandy = PlayerPrefs.GetInt ("CandyScore");
		tempCandy += candyScore;
		PlayerPrefs.SetInt ("CandyScore", tempCandy);
		int temp = Mathf.Max (PlayerPrefs.GetInt ("HighScore"), newScore);
		PlayerPrefs.SetInt ("HighScore", temp);
		bestScore.text = PlayerPrefs.GetInt ("HighScore").ToString();
	}

	public void loadScore(){
	
		gameplayed.text = PlayerPrefs.GetInt ("GamePlayed").ToString ();
		candyScore.text = PlayerPrefs.GetInt ("CandyScore").ToString ();
		bestScore.text = PlayerPrefs.GetInt ("HighScore").ToString();
	}

}
