using UnityEngine;
using System.Collections;

public class Shrubbery : MonoBehaviour {
	private string state = "";
	Animation spawn;
	GameObject scroller;
	GameObject tim;
	Tim timScript;
	bool noActionTaken = true;


	public float endPos = 5;
	public float animationTime = 4;
	public float timeUntilAction = 2;

	// Use this for initialization
	void Start () {
		spawn = gameObject.GetComponent<Animation> ();
		spawn.Play ("monsterspawn");
		scroller = GameObject.FindWithTag ("scroller");
		tim = GameObject.FindWithTag ("tim");
		timScript = tim.GetComponent<Tim> ();
	}

	// Update is called once per frame
	void Update () {


		if(gameObject.transform.position.x <= endPos){
			scroller.GetComponent<ScrollingBackground> ().stopScroll ();
			CheckGameState ();

			StartCoroutine (waitForAction(timeUntilAction));
		}
	}

	void Act(){
		if(state == "start"){
			if(timScript.mood < 5){
				print ("Tim collects some of the berries");
				StartCoroutine (waitForAnim(animationTime));
				timScript.inventory.Add ("berries");
				noActionTaken = false;
				timScript.gameState = "Bunny1";
			}

			if (timScript.mood >= 5) {
				print ("Tim smashes the berries because of angry");
				StartCoroutine (waitForAnim(animationTime));
				noActionTaken = false;
				timScript.gameState = "Stones";
			}
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

	IEnumerator waitForAction(float waitTime){
		yield return new WaitForSeconds (waitTime);
		if(noActionTaken == true){
			Act ();
		}
	}
}
