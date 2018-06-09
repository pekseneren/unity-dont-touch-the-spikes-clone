using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSpawnController : MonoBehaviour {

	//-----Level ve SpikeList değişkenleri-----
	public static List<GameObject> randomSpikes = new List<GameObject> ();
	static int minLevel;
	static int maxLevel;
	float spikeSize;

	// Use this for initialization
	void Start () {
		minLevel = 0;
		maxLevel = 2;
		var tempSpk = GameObject.FindGameObjectWithTag ("solSpike");
		spikeSize = tempSpk.GetComponent<Renderer> ().bounds.size.x;
	}


	//--------Random Spikeları döndürür--------
	public List<GameObject> randomSpike(List<GameObject> spikeList) {

		minLevel++;
		maxLevel++;

		minLevel = Mathf.Min (5, minLevel);
		maxLevel = Mathf.Min (8, maxLevel);

		randomSpikes.Clear ();

		int randArrayLenght = Random.Range (minLevel, maxLevel);


		for (int i = 0; i < randArrayLenght; i++) {
			int randArrayNumber = Random.Range (0, spikeList.Count);
			randomSpikes.Add(spikeList[randArrayNumber]);
			spikeList.RemoveAt (randArrayNumber);
			}
			
		return randomSpikes;
	}

	//-------Gönderilen SpikeList ini spawnlar---------
	public void spawnSpikes(List<GameObject> spawnSpikeList, bool wall)
	{
		if (wall == false) {
			
				for (int i = 0; i < spawnSpikeList.Count; i++) {
				spawnSpikeList[i].transform.position = 
					new Vector3(
						spawnSpikeList[i].transform.position.x + spikeSize,
						spawnSpikeList[i].transform.position.y,
						spawnSpikeList[i].transform.position.z);
				}

		}
		if (wall == true) {
			for (int i = 0; i < spawnSpikeList.Count; i++) {
				spawnSpikeList[i].transform.position = 
					new Vector3(
						spawnSpikeList[i].transform.position.x - spikeSize,
						spawnSpikeList[i].transform.position.y,
						spawnSpikeList[i].transform.position.z);
			}
		}
	}

	//-------Gönderilen SpikeList ini removelar---------
	public void removeSpikes(List<GameObject> removeSpikeList, bool a){

		if (a==false) {
			for (int i = 0; i < removeSpikeList.Count; i++) {
				removeSpikeList[i].transform.position = 
					new Vector3(
						removeSpikeList[i].transform.position.x + spikeSize,
						removeSpikeList[i].transform.position.y,
						removeSpikeList[i].transform.position.z);
			}
		}
		if (a==true) {
			for (int i = 0; i < removeSpikeList.Count; i++) {
				removeSpikeList[i].transform.position = 
					new Vector3(
						removeSpikeList[i].transform.position.x - spikeSize,
						removeSpikeList[i].transform.position.y,
						removeSpikeList[i].transform.position.z);
			}
		}
	}
}
