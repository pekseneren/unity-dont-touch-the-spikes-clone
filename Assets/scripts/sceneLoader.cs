using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class sceneLoader : MonoBehaviour {

	Camera maincam;

	public void sceneLoad(string tag){

		Debug.Log (tag);
		if(tag=="TapToJump" && Time.realtimeSinceStartup>3)
			SceneManager.LoadScene (1);
		//SceneManager.LoadScene (0);
		//SceneManager.LoadScene (tag);
		//Debug.Log ("bastı123213");
		//if(GameObject.FindGameObjectWithTag("Player")==null)

		if (tag == "gameOver")
			SceneManager.LoadScene (1);

	}

	public void buttonClick(){

		SceneManager.LoadScene (EventSystem.current.currentSelectedGameObject.name);
	}
		
}