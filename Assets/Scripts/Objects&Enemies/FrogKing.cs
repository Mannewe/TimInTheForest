using UnityEngine;
using System.Collections;

public class FrogKing : MonoBehaviour {
	private string state = "";
	Animation spawn;
	GameObject scroller;
	GameObject scroller1;
	GameObject scroller2;
	GameObject tim;
	GameObject bunny;
	Animation animBunny;
	string frogDialog = "";
	string speak;

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
		bunny = GameObject.FindWithTag ("BunnyFollower");
		animBunny = bunny.GetComponent<Animation> ();
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
			if (state == "Frog1") {
				if (timScript.mood < 5) {
					print ("Tim erbjuder grodan att få kaninen som kompis. Grodan blir överlycklig och ger Tim en blomma som tack.");
					frogDialog = "Take this flower as a token of our friendship";
					animBunny.Play ("giveLivingRabbit");
					timScript.inventory.Add ("Flower");
					StartCoroutine (waitForAnim (animationTime));
					//timScript.bunnyFollower.SetActive (false);
					noActionTaken = false;
					timScript.gameState = "Flower1";
				}

				if (timScript.mood >= 5) {
					print ("Tim slår grodan med sin pinne. Grodan flyr från Tims vrede, och tappar sitt svärd.");
					frogDialog = "Ah, stop! Don’t hurt me! Get away from me!";
					timScript.animStick.SetActive (true);
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("Killstuff");
					timScript.inventory.Remove ("Stick");
					noActionTaken = false;
					timScript.gameState = "Sword1";
				}
			}

			if (state == "Frog2") {
				if (timScript.mood < 5) {
					frogDialog = "Finally a friend, thank you stranger! \n Take this flower as a token of our friendship";
					print ("Tim erbjuder grodan att få kaninen som kompis. Grodan blir överlycklig och ger Tim en blomma som tack.");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Add ("Flower");
					timScript.bunnyFollower.SetActive (false);
					noActionTaken = false;
					timScript.gameState = "Flower2";
				}

				if (timScript.mood >= 5) {
					frogDialog = "So you wanna fight, huh? I’ll show you!";
					print ("Tim brottas med grodan, men förlorar. Grodan tar Tim till sin personliga slav.");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Slave1";
				}
			}

			if (state == "Frog3") {
				if (timScript.mood < 5) {
					frogDialog = "You’re my slave now. S for sockdrying,\n L for laundry, A for assmassage,\n V for victim, E for eat my shit";
					print ("Då Tim inte har någonting att ge grodan, gör grodan Tim till sin personliga slav. ");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Slave2";
				}

				if (timScript.mood >= 5) {
					frogDialog = "How convenient, my last slave just died. \n You’ll be a worthy replacement";
					print ("Då Tim inte har någonting att ge grodan, gör grodan Tim till sin personliga slav.");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Slave2";
				}
			}

			if (state == "Frog4") {
				if (timScript.mood < 5) {
					frogDialog = "Such a lovely mushroom, you’ll be my personal mushroom picker!";
					print ("Tim ger grodan den fina svampen. Grodan uppskattar detta så mycket att han tar Tim till sin personliga slav. ");
					timScript.throwGoodMushroom.Play ("berryThrow");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("MushroomGood");
					noActionTaken = false;
					timScript.gameState = "Slave2";
				}

				if (timScript.mood >= 5) {
					frogDialog = "Worth… it…";
					print ("Tim ger grodan den giftiga svampen. Grodan dör och tappar sitt svärd, som Tim plockar upp.");
					timScript.throwBadMushroom.Play ("berryThrow");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("MushroomBad");
					timScript.inventory.Add ("Sword");
					noActionTaken = false;
					timScript.gameState = "Sword2";
				}
			}

			if (state == "Frog5") {
				if (timScript.mood < 5) {
					frogDialog = "How nice to finally get some company! I’ll show you the way out of the forest.";
					print ("Tim ger grodan den döda kaninen. Grodan uppskattar gåvan, och de två blir kompisar. Grodan visar Tim vägen ut ur skogen. ");
					timScript.throwDeadRabbit.Play ("berryThrow");
					StartCoroutine (waitForAnim (animationTime));
					timScript.inventory.Remove ("RabbitDead");
					noActionTaken = false;
					timScript.gameState = "OutOfTheForest1";
				}

				if (timScript.mood >= 5) {
					//swordPos = -1f;
					frogDialog = "Fiona, forgive me…";
					print ("Tim dräper grodan med sitt svärd. Tim tar grodans ledbrutna kropp och lägger den i sin ryggsäck.");
					timScript.animSword.SetActive (true);
					StartCoroutine (waitForAnim (animationTime));
					timScript.animScared.Play ("Killstuff");
					//timScript.inventory.Remove ("Sword");
					timScript.inventory.Add ("FrogDead");
					noActionTaken = false;
					timScript.gameState = "Dragon5";
				}
			}
		}
	}

	void Destroy(){
		if (gameObject.activeSelf == true) {
			gameObject.SetActive (false);
			timScript.pratbubblaAndra2.SetActive (false);
		}
	}

	void CheckGameState(){
		state = tim.GetComponent<Tim> ().gameState;
	}

	IEnumerator waitForAnim(float waitTime){
		yield return new WaitForSeconds (waitTime);
		print ("Animation Done");
		timScript.bunnyFollower.SetActive (false);
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
			StartCoroutine (waitForBubble(4.0f));
		}
	}

	IEnumerator waitForBubble(float waitTime){
		yield return new WaitForSeconds (waitTime);
		timScript.pratbubblaAndra2.SetActive (true);
		speak = frogDialog;
	}

	void OnGUI(){
		GUI.Label(new Rect(700,50,200,190), speak , timScript.style);
	}
}
