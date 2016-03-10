using UnityEngine;
using System.Collections;


public class Stick : MonoBehaviour {
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
		if (timScript.moodChanged == true) {
			if (state == "Stick1") {
				if (timScript.mood < 5) {
					print ("Tim plockar upp en pinne som han hittar på marken.");
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("shrubbery");
					timScript.inventory.Add ("Stick");
					noActionTaken = false;
					timScript.gameState = "Mushroom1";
				}

				if (timScript.mood >= 5) {
					print ("Tim plockar upp en pinne som han hittar på marken.");
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("shrubbery");
					timScript.inventory.Add ("Stick");
					noActionTaken = false;
					timScript.gameState = "Mushroom1";
				}
			}

			if (state == "Stick2") {
				if (timScript.mood < 5) {
					print ("Tim plockar upp pinnen");
					timScript.animScared.Play ("shrubbery");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Add ("Stick");
					noActionTaken = false;
					timScript.gameState = "Frog1";
				}

				if (timScript.mood >= 5) {
					print ("Tim förstör pinnen i sin ilska.");
					timScript.animScared.Play ("stickdestroy");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Frog2";
				}
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

	IEnumerator waitForAction(float waitTime){
		yield return new WaitForSeconds (waitTime);
		if(noActionTaken == true){
			Act ();
		}
	}
}