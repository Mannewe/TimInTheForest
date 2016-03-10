using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemiesObjects;
	GameObject tim;
	Tim timScript;

	// Use this for initialization
	void Start () {
		tim = GameObject.FindWithTag ("tim");
		timScript = tim.GetComponent<Tim> ();

		StartCoroutine (WaitForSpawn(Random.Range(4f,8f)));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitForSpawn(float waitTime){
		yield return new WaitForSeconds (waitTime);

		if(timScript.gameState == "Bunny1"){
			if(timScript.mood > 0 && timScript.mood < 10){
		GameObject Bunny1 = (GameObject)Instantiate (enemiesObjects [1]);
			}
		}

		if(timScript.gameState == "Stones1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Stone = (GameObject)Instantiate (enemiesObjects [2]);
			}
		}

		if(timScript.gameState == "Raven1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Raven = (GameObject)Instantiate (enemiesObjects [7]);
			}
		}

		if(timScript.gameState == "Bunny2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Bunny2 = (GameObject)Instantiate (enemiesObjects [1]);
			}
		}

		if(timScript.gameState == "Stick1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Stick1 = (GameObject)Instantiate (enemiesObjects [9]);
			}
		}

		if(timScript.gameState == "Berries"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Berries = (GameObject)Instantiate (enemiesObjects [0]);
			}
		}

		if(timScript.gameState == "Stick2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Stick2 = (GameObject)Instantiate (enemiesObjects [9]);
			}
		}

		if(timScript.gameState == "Raven2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Raven2 = (GameObject)Instantiate (enemiesObjects [7]);
			}
		}

		if(timScript.gameState == "Frog1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Frog1 = (GameObject)Instantiate (enemiesObjects [8]);
			}
		}

		if(timScript.gameState == "Frog2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Frog2 = (GameObject)Instantiate (enemiesObjects [8]);
			}
		}

		if(timScript.gameState == "Frog3"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Frog3 = (GameObject)Instantiate (enemiesObjects [8]);
			}
		}

		if(timScript.gameState == "Frog4"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Frog4 = (GameObject)Instantiate (enemiesObjects [8]);
			}
		}

		if(timScript.gameState == "Frog5"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Frog5 = (GameObject)Instantiate (enemiesObjects [8]);
			}
		}

		if(timScript.gameState == "Mushroom1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Mushroom1 = (GameObject)Instantiate (enemiesObjects [3]);
				GameObject Mushroom2 = (GameObject)Instantiate (enemiesObjects [5]);
			}
		}

		if(timScript.gameState == "Flower1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Flower1 = (GameObject)Instantiate (enemiesObjects [4]);
			}
			timScript.TimDialogHappy.Clear ();
			timScript.TimDialogScared.Clear ();
			timScript.TimDialogAngry.Clear ();
		}

		if(timScript.gameState == "Flower2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Flower2 = (GameObject)Instantiate (enemiesObjects [4]);
			}
		}

		if(timScript.gameState == "Sword1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Sword1 = (GameObject)Instantiate (enemiesObjects [10]);
			}
		}

		if(timScript.gameState == "Sword2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Sword2 = (GameObject)Instantiate (enemiesObjects [10]);
			}
		}

		if(timScript.gameState == "Sword3"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Sword3 = (GameObject)Instantiate (enemiesObjects [10]);
			}
		}

		if(timScript.gameState == "Dragon1"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Dragon1 = (GameObject)Instantiate (enemiesObjects [6]);
			}
		}

		if(timScript.gameState == "Dragon2"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Dragon2 = (GameObject)Instantiate (enemiesObjects [6]);
			}
		}

		if(timScript.gameState == "Dragon3"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Dragon3 = (GameObject)Instantiate (enemiesObjects [6]);
			}
		}

		if(timScript.gameState == "Dragon4"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Dragon4 = (GameObject)Instantiate (enemiesObjects [6]);
			}
		}

		if(timScript.gameState == "Dragon5"){
			if (timScript.mood > 0 && timScript.mood < 10) {
				GameObject Dragon5 = (GameObject)Instantiate (enemiesObjects [6]);
			}
		}

//		if(timScript.gameState == "Slave1"){
//			GameObject Slave1 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Slave2"){
//			GameObject Slave2 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Peace1"){
//			GameObject Peace1 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Peace2"){
//			GameObject Peace2 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Death1"){
//			GameObject Death1 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Death2"){
//			GameObject Death2 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Death3"){
//			GameObject Death3 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Death4"){
//			GameObject Death4 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Lost1"){
//			GameObject Lost1 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "Lost2"){
//			GameObject Lost2 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "OutOfTheForest1"){
//			GameObject OutOfTheForest1 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "OutOfTheForest2"){
//			GameObject OutOfTheForest2 = (GameObject)Instantiate (enemiesObjects [0]);
//		}
//
//		if(timScript.gameState == "King1"){
//			GameObject King1 = (GameObject)Instantiate (enemiesObjects [0]);
//		}

		StartCoroutine (WaitForSpawn(Random.Range(20f,35f)));
	}
}
