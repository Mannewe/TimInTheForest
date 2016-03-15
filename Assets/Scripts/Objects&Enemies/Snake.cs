using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
	private string state = "";
	Animation spawn;
	GameObject scroller;
	GameObject scroller1;
	GameObject scroller2;
	GameObject tim;
	GameObject sword;
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
		sword = GameObject.FindWithTag ("animSword");
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
			if (state == "Dragon1") {
				if (timScript.mood < 5) {
					print ("Tim ger sin blomma till ormen, som blir glad över Tims omtanke och de två blir kompisar. Fred råder i skogen, och alla lever lyckliga. ");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("Flower");
					noActionTaken = false;
					timScript.gameState = "Peace1";

				}

				if (timScript.mood >= 5) {
					print ("Tim gör ett utfall med sin pinne mot drakormen. Pinnen förstörs och Tim blir uppäten av monstret. Tim är död.");
					timScript.animStick.SetActive (true);
					timScript.animScared.Play ("Killstuff");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("Stick");
					noActionTaken = false;
					timScript.gameState = "Death1";
				}
			}

			if (state == "Dragon2") {
				if (timScript.mood < 5) {
					print ("Tim försöker desperat att bli vän med ormen. Ormen är dock inte intresserad av något annat än att äta upp Tim, vilket den gör med stor aptit. Tim är död. ");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Death2";
				}

				if (timScript.mood >= 5) {
					print ("Tim dräper ormen med ett kraftfullt slag. Med drakormens död har Tim besegrat ondskan som terroriserat skogen, men är dömd att vara vilse i all oändlighet. \n");
					timScript.animScared.Play ("Killstuff");
					timScript.animSword.SetActive (true);
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Lost1";
				}
			}

			if (state == "Dragon3") {
				if (timScript.mood < 5) {
					print ("Tim ger sin blomma till ormen, som blir glad över Tims omtanke och de två blir kompisar. Fred råder i skogen, och alla lever lyckliga. ");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("Flower");
					noActionTaken = false;
					timScript.gameState = "Peace2";
				}

				if (timScript.mood >= 5) {
					print ("Tim anfaller ormen med sina bara händer. Detta visar sig vara en dålig ide, då ormen äter upp Tim i ett nafs.");
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("Killstuff");
					noActionTaken = false;
					timScript.gameState = "Death3";
				}
			}

			if (state == "Dragon4") {
				if (timScript.mood < 5) {
					print ("Tim försöker desperat att bli vän med ormen. Ormen är dock inte intresserad av något annat än att äta upp Tim, vilket den gör med stor aptit. Tim är död.");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Death4";
				}

				if (timScript.mood >= 5) {
					timScript.animSword.SetActive (true);
					print ("Tim dräper ormen med ett kraftfullt slag. Med drakormens död har Tim besegrat ondskan som terroriserat skogen, men är dömd att vara vilse i all oändlighet. ");
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("Killstuff");
					noActionTaken = false;
					timScript.gameState = "Lost2";
				}
			}

			if (state == "Dragon5") {
				if (timScript.mood < 5) {
					print ("Tim ger den döda grodans kropp till drakormen. Drakormen äter upp grodan med stor aptit. Tim och drakormen blir kompisar, och ormen visar Tim vägen ut ur skogen.");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("FrogDead");
					noActionTaken = false;
					timScript.gameState = "OutOfTheForest2";
				}

				if (timScript.mood >= 5) {
					timScript.animSword.SetActive (true);
					print ("Tim gör ett fasansfullt utfall mot drakormen, och dräper den med ett stort leende på läpparna. Tim har nu besegrat skogens makthavare, och är nu själv skogens herre och kung.");
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("Killstuff");
					noActionTaken = false;
					timScript.gameState = "King1";
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
		if(timScript.animSword.activeSelf == true){
			timScript.animSword.SetActive (false);
		}
		if(timScript.animStick.activeSelf == true){
			timScript.animStick.SetActive (false);
		}
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
