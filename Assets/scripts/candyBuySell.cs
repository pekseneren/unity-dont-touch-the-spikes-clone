using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class candyBuySell : MonoBehaviour {

	// Use this for initialization
	public Text candyScore;
	public Text shopCandyScore;
	public Text diamondScore;
	public Text birdShopDiamondScore;


	void Start(){

		loadScore ();
	}

	public void Sell(){
		if(PlayerPrefs.GetInt ("CandyScore")>750)
			PlayerPrefs.SetInt ("CandyScore", PlayerPrefs.GetInt ("CandyScore") - 750);
		loadScore ();
	}

	public void Buy(){

		PlayerPrefs.SetInt ("CandyScore", PlayerPrefs.GetInt ("CandyScore") + 400);
		loadScore ();
	}

	public void loadScore(){

		diamondScore.text = PlayerPrefs.GetInt ("DiamondScore").ToString ();
		shopCandyScore.text = PlayerPrefs.GetInt ("CandyScore").ToString ();
		candyScore.text = PlayerPrefs.GetInt ("CandyScore").ToString ();
		birdShopDiamondScore.text = PlayerPrefs.GetInt ("DiamondScore").ToString ();
	}

	public void BuyDiamonds()
	{
		PlayerPrefs.SetInt ("DiamondScore", PlayerPrefs.GetInt ("DiamondScore") + 10);
		loadScore ();
	}

	public void DiamondSell()
	{
		if(PlayerPrefs.GetInt ("DiamondScore")>50)
			PlayerPrefs.SetInt ("DiamondScore", PlayerPrefs.GetInt ("DiamondScore") - 50);
		loadScore ();
	}
}
