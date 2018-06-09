using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {

	void Start(){
		Screen.SetResolution(480, 854, true);
	}

	void Update () {
		if (Time.timeSinceLevelLoad > 5)
			SceneManager.LoadScene (1);
	}
}
