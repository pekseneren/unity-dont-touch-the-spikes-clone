using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class loadScene : MonoBehaviour {

	public Button btn;


	void Start(){
		
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (OnMouseDown);
	}
		
	void OnMouseDown(){
		
		sceneLoader scene = GameObject.Find ("sceneManager").GetComponent<sceneLoader> ();
		Debug.Log (btn.name);
		scene.sceneLoad (btn.name);
	}

}
