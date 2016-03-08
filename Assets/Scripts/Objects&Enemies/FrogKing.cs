using UnityEngine;
using System.Collections;

public class FrogKing : MonoBehaviour {
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
		if(state == "Frog1"){
			if(timScript.mood < 5){
				print ("Tim erbjuder grodan att få kaninen som kompis. Grodan blir överlycklig och ger Tim en blomma som tack.");
				timScript.inventory.Add ("Flower");
				StartCoroutine (waitForAnim(animationTime));
				timScript.bunnyFollower.SetActive (false);
				noActionTaken = false;
				timScript.gameState = "Flower1";
			}

			if (timScript.mood >= 5) {
				print ("Tim slår grodan med sin pinne. Grodan flyr från Tims vrede, och tappar sitt svärd.");
				StartCoroutine (waitForAnim(animationTime));
				timScript.animScared.Play ("Killstuff");
				timScript.inventory.Remove ("Stick");
				noActionTaken = false;
				timScript.gameState = "Sword1";
			}
		}

		if(state == "Frog2"){
			if(timScript.mood < 5){
				print ("Tim erbjuder grodan att få kaninen som kompis. Grodan blir överlycklig och ger Tim en blomma som tack.");
				StartCoroutine (waitForAnim(animationTime));
				timScript.inventory.Add ("Flower");
				timScript.bunnyFollower.SetActive (false);
				noActionTaken = false;
				timScript.gameState = "Flower2";
			}

			if (timScript.mood >= 5) {
				print ("Tim brottas med grodan, men förlorar. Grodan tar Tim till sin personliga slav.");
				StartCoroutine (waitForAnim(animationTime));
				noActionTaken = false;
				timScript.gameState = "Slave1";
			}
		}

		if(state == "Frog3"){
			if(timScript.mood < 5){
				print ("Då Tim inte har någonting att ge grodan, gör grodan Tim till sin personliga slav. ");
				StartCoroutine (waitForAnim(animationTime));
				noActionTaken = false;
				timScript.gameState = "Slave2";
			}

			if (timScript.mood >= 5) {
				print ("Då Tim inte har någonting att ge grodan, gör grodan Tim till sin personliga slav.");
				StartCoroutine (waitForAnim(animationTime));
				noActionTaken = false;
				timScript.gameState = "Slave2";
			}
		}

		if(state == "Frog4"){
			if(timScript.mood < 5){
				print ("Tim ger grodan den fina svampen. Grodan uppskattar detta så mycket att han tar Tim till sin personliga slav. ");
				StartCoroutine (waitForAnim(animationTime));
				timScript.inventory.Remove ("MushroomGood");
				noActionTaken = false;
				timScript.gameState = "Slave2";
			}

			if (timScript.mood >= 5) {
				print ("Tim ger grodan den giftiga svampen. Grodan dör och tappar sitt svärd, som Tim plockar upp.");
				StartCoroutine (waitForAnim(animationTime));
				timScript.inventory.Remove ("MushroomBad");
				timScript.inventory.Add ("Sword");
				noActionTaken = false;
				timScript.gameState = "Sword2";
			}
		}

		if(state == "Frog5"){
			if(timScript.mood < 5){
				print ("Tim ger grodan den döda kaninen. Grodan uppskattar gåvan, och de två blir kompisar. Grodan visar Tim vägen ut ur skogen. ");
				StartCoroutine (waitForAnim(animationTime));
				timScript.inventory.Remove ("RabbitDead");
				noActionTaken = false;
				timScript.gameState = "OutOfTheForest1";
			}

			if (timScript.mood >= 5) {
				print ("Tim dräper grodan med sitt svärd. Tim tar grodans ledbrutna kropp och lägger den i sin ryggsäck.");
				StartCoroutine (waitForAnim(animationTime));
				timScript.animScared.Play ("Killstuff");
				timScript.inventory.Remove ("Sword");
				timScript.inventory.Add ("FrogDead");
				noActionTaken = false;
				timScript.gameState = "Dragon5";
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
