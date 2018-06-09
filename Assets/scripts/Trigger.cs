using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
	

	public GameObject obj;
	public GameObject obj2;
	public Text point;
	public static int i=0;
	Scene scn;

	// Use this for initialization
	void Start () {
		//ilkSpikelariCikar ();
		scn = SceneManager.GetActiveScene ();

		if (scn.name == "DTTS")
			i = 0;

		if (scn.name == "gameOver")
			point.text = i.ToString ();
		
	}

	void Update(){


	}

	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.tag == "Player") {
			kusunYonunuDegistir ();
			scoreArttir ();
		}

	}
		

	//Kusun baktığı yön ve gittiği yön değiştirilir
	public void kusunYonunuDegistir(){
		
		obj.transform.Rotate (new Vector3 (0, 180, 0));
		if (obj.GetComponent<birdy> ().c == true) {
			obj.GetComponent<birdy> ().c = false;
			obj2.GetComponent<sekerUret> ().b = true;
		}

	}


	//Ölmeden değildiğinde duvara skor +1 arttırılır text değeri değiştirilir
	void scoreArttir(){
		
		i = i + 1;
		if(i<10)
		obj.GetComponent<birdy> ().scriptText.text = "0"+i.ToString ();
		else
		obj.GetComponent<birdy> ().scriptText.text = i.ToString ();

	}

}

