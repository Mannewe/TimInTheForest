using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {
	private string state = "";
	Animation spawn;
	GameObject scroller;
	GameObject scroller1;
	GameObject scroller2;
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
		scroller = GameObject.FindWithTag ("scroller1");
		scroller1 = GameObject.FindWithTag ("scroller2");
		scroller2 = GameObject.FindWithTag ("scroller3");
		tim = GameObject.FindWithTag ("tim");
		timScript = tim.GetComponent<Tim> ();

	}

	// Update is called once per frame
	void Update () {


		if(gameObject.transform.position.x <= endPos){
			scroller.GetComponent<ScrollingBackground> ().stopScroll ();
			scroller1.GetComponent<ScrollingBackground> ().stopScroll ();
			scroller2.GetComponent<ScrollingBackground> ().stopScroll ();
			CheckGameState ();

			StartCoroutine (waitForAction(timeUntilAction));
		}
	}

	void Act(){
		if(state == "Bunny1"){
			if(timScript.mood < 5){
				print ("Tim ger sina bär till kaninen, som väljer att slå följe med Tim.");
				StartCoroutine (waitForAnim(animationTime));
				StartCoroutine (waitForBunny(animationTime - 0.1f));
				timScript.inventory.Remove ("Berries");
				noActionTaken = false;
				timScript.gameState = "Raven1";
			}

			if (timScript.mood >= 5) {
				print ("Tim skrämmer iväg kaninen.");
				StartCoroutine (waitForAnim(animationTime));
				noActionTaken = false;
				timScript.gameState = "Stick1";
			}
		}

		if(state == "Bunny2"){
			if(timScript.mood < 5){
				print ("Tim ignorerar kaninen, och går vidare.");
				StartCoroutine (waitForAnim(animationTime));
				noActionTaken = false;
				timScript.gameState = "Stick1";
			}

			if (timScript.mood >= 5) {
				print ("Tim kastar en av sina stenar på kaninen, som dör. Tim plockar upp den döda kaninen och lägger den i sin ryggsäck.");
				StartCoroutine (waitForAnim(animationTime));
				timScript.inventory.Remove ("Stone1");
				noActionTaken = false;
				timScript.gameState = "Raven2";
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
		scroller.GetComponent<ScrollingBackground> ().startScroll ();
		scroller1.GetComponent<ScrollingBackground> ().startScroll ();
		scroller2.GetComponent<ScrollingBackground> ().startScroll ();
		Destroy ();

	}

	IEnumerator waitForBunny(float waitTime){
		yield return new WaitForSeconds (waitTime);
		timScript.bunnyFollower.SetActive (true);
	}

	IEnumerator waitForAction(float waitTime){
		yield return new WaitForSeconds (waitTime);
		if(noActionTaken == true){
			Act ();
		}
	}
}
