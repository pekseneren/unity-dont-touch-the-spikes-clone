using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class birdy : MonoBehaviour {

	public Animator animator;
	public Animator bestScoreAnimator;
	public Animator gamePlayedAnimator;
	public Animator candyScoreAnimator;
	//public Animator arti;
	public static bool gameStarted = false;
	public List<GameObject> buttonList = new List<GameObject>();

	[Header("Spike Controller")]
	public spikeSpawnController spk;

	[Space]

	[Header("Sol Ve Sağ Spikelar")]
	public float size;
	public List<GameObject> solSpikes = new List<GameObject>();
	public List<GameObject> sagSpikes = new List<GameObject>();

	[Space]

	[Header("RandomSol Ve RandomSağ Spikelar")]
	public List<GameObject> randomSagDuvarSpikelari = new List<GameObject>();
	public List<GameObject> randomSolDuvarSpikelari = new List<GameObject>();

	[Space]

	[Header("ScoreCounter")]
	//----ScoreCounter CandCounter----
	public Text scriptText;
	public int sekerSkoru;

	[Space]

	[Header("Yön Değişim")]
	public static bool wall = true;
	public bool c = false;

	[Space]

	[Header("Yer Çekimi ve Hız")]
	public GameObject obj;
	public Vector3 gravity;
	public Vector3 flapvelocity;
	Vector3 velocity = Vector3.zero;
	public float maxspeed = 3f;
	public float fowardspeed = 1f;
	bool didflap = true;

	// Use this for initialization
	void Start () {

		Screen.SetResolution(480, 854, true);

		bestScoreAnimator.ResetTrigger ("trigger");

		gameStarted = false;
		sekerSkoru = 0;

		var buttonArray = GameObject.FindGameObjectsWithTag ("HardMode");

		for (int i = 0; i < buttonArray.Length; i++) {

			buttonList.Add (buttonArray [i]);
		}

		wall = true;

		var tempSolSpk = GameObject.FindGameObjectsWithTag ("solSpike");
		var tempSagSpk = GameObject.FindGameObjectsWithTag ("sagSpike");

		//--------Spikelari gameobject list'e ata--------
		for (int i = 0; i <tempSolSpk.Length ; i++) {
			solSpikes.Add (tempSolSpk [i]);
		}
		for (int i = 0; i <tempSagSpk.Length ; i++) {
			sagSpikes.Add (tempSagSpk [i]);
		}

		size = solSpikes [0].GetComponent<Renderer> ().bounds.size.x;
	}

	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown(0))
		{
			// Check if the mouse was clicked over a UI element
			if (EventSystem.current.IsPointerOverGameObject() && gameStarted==false){
				
			}
			else{
				GameObject.FindGameObjectWithTag ("Menu").GetComponent<SpriteRenderer> ().sortingLayerName = "asd";
				animator.enabled = false;
				didflap = true;

                gameStarted = true;
				bestScoreAnimator.SetTrigger ("trigger");
				gamePlayedAnimator.SetTrigger ("trigger");
				candyScoreAnimator.SetTrigger ("trigger");

				gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "Default";

				if(gameStarted == true && buttonList!=null){

					GameObject.FindGameObjectWithTag ("seker").GetComponent<SpriteRenderer> ().sortingLayerName = "Player";

					scriptText.transform.position = obj.transform.position;

					for (int i = 0; i < buttonList.Count; i++) {

						Destroy (buttonList [i]);
					}

					buttonList.Clear ();
					buttonList = null;
				}
			}
		}
        
    }


	void FixedUpdate(){
        hizHesaplari();
    }


	void OnTriggerEnter2D(Collider2D collider){

		if (collider.tag == "seker") {

			//GameObject.FindGameObjectWithTag ("+1").transform.position = GameObject.FindGameObjectWithTag ("seker").transform.position;
			//arti.SetTrigger ("trigger");

			obj.GetComponent<sekerUret> ().a = true;
			c = true;
			sekerSkoru++;
		}

		//----Sag Duvar için spike çıkar sol duvarın spikelarını içeri al--------
		if (collider.tag == "sagDuvar") {
			wall = false; 
			spk.removeSpikes (randomSagDuvarSpikelari, wall);
			randomSagDuvarSpikelari.Clear ();
			randomSolDuvarSpikelari = spk.randomSpike (solSpikes);
			spk.spawnSpikes (randomSolDuvarSpikelari, wall);
			for (int i = 0; i < randomSolDuvarSpikelari.Count; i++) {
				solSpikes.Add (randomSolDuvarSpikelari [i]);
			}
		}

		//----Sol Duvar için spike çıkar sağ duvarın spikelarını içeri al--------
		if (collider.tag == "solDuvar") {
			wall = true;
			spk.removeSpikes (randomSolDuvarSpikelari, wall);
			randomSolDuvarSpikelari.Clear ();
			randomSagDuvarSpikelari = spk.randomSpike (sagSpikes);
			spk.spawnSpikes (randomSagDuvarSpikelari,wall);
			for (int i = 0; i < randomSagDuvarSpikelari.Count; i++) {
				sagSpikes.Add (randomSagDuvarSpikelari [i]);
			}
		}
	}


    //---Kuşun yönü sağa mı ? sola mı ?--DeltaTime kadar yerçekimi uygula--Zıplat--Maksimum Hızı geçmesini engelle---
    void hizHesaplari()
    {

        this.velocity.x = !birdy.wall ? -this.fowardspeed : this.fowardspeed;
        this.velocity += this.gravity * Time.deltaTime;
        if (this.didflap)
        {
            this.didflap = false;
            if ((double)this.velocity.y < 0.0)
                this.velocity.y = 0.0f;
            this.velocity += this.flapvelocity;
        }
        this.velocity = Vector3.ClampMagnitude(this.velocity, this.maxspeed);
        this.transform.position += this.velocity * Time.deltaTime;
    }
}
