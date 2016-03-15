using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
	GameObject tim;
	Tim timScript;
	bool changeScene = false;
	// Use this for initialization
	void Start () {
		tim = GameObject.FindWithTag ("tim");
		timScript = tim.GetComponent<Tim> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(timScript.gameState == "Death1"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("death1");
			}
		}

		if(timScript.gameState == "Death2"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("death2");
			}
		}

		if(timScript.gameState == "Death3"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("death3");
			}
		}

		if(timScript.gameState == "Death4"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("death4");
			}
		}

		if(timScript.gameState == "Peace1"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("peace1");
			}
		}

		if(timScript.gameState == "Peace2"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("peace1");
			}
		}

		if(timScript.gameState == "Lost1"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("lost");
			}
		}

		if(timScript.gameState == "Lost2"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("lost");
			}
		}

		if(timScript.gameState == "Slave1"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("slave1");
			}
		}

		if(timScript.gameState == "Slave2"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("slave2");
			}
		}

		if(timScript.gameState == "Slave3"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("slave3");
			}
		}

		if(timScript.gameState == "OutOfTheForest1"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("outoftheforest1");
			}
		}

		if(timScript.gameState == "OutOfTheForest2"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("outoftheforest2");
			}
		}

		if(timScript.gameState == "King1"){
			StartCoroutine (waitForScene (8));
			if(changeScene == true){
				SceneManager.LoadScene ("King1");
			}
		}
	}

	IEnumerator waitForScene(float waitTime){
		yield return new WaitForSeconds (waitTime);
		float fadeTime = GameObject.Find ("GM").GetComponent<Fade> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		changeScene = true;
	}
}
