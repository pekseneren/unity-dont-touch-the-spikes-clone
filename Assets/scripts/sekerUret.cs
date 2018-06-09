using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sekerUret : MonoBehaviour {

	public GameObject back;
	public static int i=0;
	public GameObject arti;
	public bool a = false;
	public bool b = true;
	Vector3 pos = new Vector3(15,15,15);
	public Text sekerSkoru;
	Scene scn;
	public birdy bird;
    public Animator animator;
	//public GameObject artiAnimation;

	// Use this for initialization
	void Start () {



		scn = SceneManager.GetActiveScene ();

		if (scn.name == "DTTS")
			i = 0;
			//artiAnimation.GetComponent<Animation> ().Stop ();


		if (scn.name == "gameOver")
			sekerSkoru.text = i.ToString ();
		else
			sekerSpawnla ();
		//back.transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (scn.name != "gameOver" && birdy.gameStarted==true) {
			sekerSakla ();
			sekerSpawnla ();
		}
	}

	//Şekerin Ekran dışına alınması...
	void sekerSakla(){
			

		   
//		   animator.SetTrigger ("trigger");

		if (a == true && birdy.gameStarted==true) {
			arti.transform.position = back.transform.position;
			a = false;
			back.transform.position = pos;
			//artiAnimation.GetComponent<Animation> ().wrapMode = WrapMode.Once;
			//artiAnimation.GetComponent<Animation> ().Play ("Fade");

			//animator.ResetTrigger ("trigger");
		}
	}

	//Şekerin yeni spawn noktası....
	void sekerSpawnla(){

		//animator.ResetTrigger ("trigger");

		if(b==true && birdy.gameStarted==true){
			
			i++;
			int[] yon = new int[2]{ -1, 1 };
			int randyonx = yon [Random.Range (0, 2)];

			float randy = Random.Range (((GetComponent<Renderer>().bounds.size.y)/2)*-1,
				(GetComponent<Renderer>().bounds.size.y)/2);

			float x = (GetComponent<Renderer> ().bounds.size.x / 2)*randyonx;

			back.transform.position = new Vector3 (0 + x, 0.5f + randy, -0.1f);
			b = false;
		}
	}


}
