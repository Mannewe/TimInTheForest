using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
	private string state = "";
	Animation spawn;
	GameObject scroller;
	GameObject tim;

	// Use this for initialization
	void Start () {
		spawn = gameObject.GetComponent<Animation> ();
			spawn.Play ("monsterspawn");
		scroller = GameObject.FindWithTag ("scroller");
		tim = GameObject.FindWithTag ("tim");
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.x <= 5){
			scroller.GetComponent<ScrollingBackground> ().stopScroll ();

			if(Input.GetKeyDown("w")){
				CheckGameState ();
				Act ();
			}

			if (Input.GetKeyDown ("s")) {
				CheckGameState ();
				Act ();
			}
		}
	}

	void Act(){
		if(state == ""){
			
		}

		if(state == "rock,flower"){
			if(Input.GetKeyDown("w")){
				print ("gets flower and is very happy");
				StartCoroutine (waitForAnim(4.0f));
			}

			if (Input.GetKeyDown ("s")) {
				print ("gets a rock in his head");
				StartCoroutine (waitForAnim(4.0f));
			}
		}

		if(state == ""){
			
		}
	}

	void Destroy(){
		if (gameObject.activeSelf == true) {
				gameObject.SetActive (false);
		}
	}

	void CheckGameState(){
		state = tim.GetComponent<Tim> ().gameState;
	}

	IEnumerator waitForAnim(float waitTime){
		yield return new WaitForSeconds (waitTime);
		print ("Animation Done");
		scroller.GetComponent<ScrollingBackground> ().startScroll ();;
		Destroy ();

	}
}
