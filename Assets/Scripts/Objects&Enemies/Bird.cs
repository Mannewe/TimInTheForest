using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	private string state = "";
	public Animation spawn;
	GameObject scroller;
	GameObject scroller1;
	GameObject scroller2;
	GameObject tim;
	public Sprite ravenFly;
	string ravenDialog = "";
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

			if(timScript.birdFly.IsPlaying("birdFlyAwayAnim")){
				spawn.Play ("wings");
			}
		}
	}

	void Act(){
		if (timScript.moodChanged == true) {
			if (state == "Raven1") {
				if (timScript.mood < 5) {
					StartCoroutine (waitForFly (6f));
					print ("Tim och kaninen möter en korp. Korpen säger: -Skogens kung är ensam. Korpen flyger iväg");
					ravenDialog = "The King of the forest is lonely.";
					timScript.pratbubblaAndra.SetActive (true);
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Stick2";
				}

				if (timScript.mood >= 5) {
					StartCoroutine (waitForFly (6f));
					print ("Tim och kaninen möter en korp. Korpen säger: -Skogens kung är ensam. Korpen flyger iväg");
					ravenDialog = "The King of the forest is \n in need of a friend.";
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.gameState = "Stick2";
				}
			}

			if (state == "Raven2") {
				if (timScript.mood < 5) {
					StartCoroutine (waitForFly (6f));
					print ("Tim möter en korp. Korpen säger: - Ormen älskar att äta grodlår. Tim kastar sin sista sten på korpen, som flyger iväg. I sin brådska tappar korpen sitt svärd på marken. Tim plockar upp svärdet.");
					ravenDialog = "Snakes loves to eat frogs’ legs.";
					timScript.rockThrow.Play ("berryThrow");
					StartCoroutine (waitForAnim (animationTime));
					noActionTaken = false;
					timScript.inventory.Remove ("Stone2");
					timScript.gameState = "Sword3";
				}

				if (timScript.mood >= 5) {
					StartCoroutine (waitForFly (6f));
					print ("Tim möter en korp. Korpen säger: - Ormen älskar att äta grodlår. Tim kastar sin sista sten på korpen, som flyger iväg. I sin brådska tappar korpen sitt svärd på marken. Tim plockar upp svärdet.");
					timScript.rockThrow.Play ("berryThrow");
					ravenDialog = "If you are a frog, beware \n of the hungry Dragonsnake.";
					StartCoroutine (waitForAnim (animationTime));
					timScript.animWings.SetActive (true);
					noActionTaken = false;
					timScript.inventory.Remove ("Stone2");
					timScript.gameState = "Sword3";
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
		timScript.pratbubblaAndra.SetActive (false);
		scroller.GetComponent<ScrollingBackground> ().startScroll ();
		scroller1.GetComponent<ScrollingBackground> ().startScroll ();
		scroller2.GetComponent<ScrollingBackground> ().startScroll ();
		timScript.animWings.SetActive (false);
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
		timScript.pratbubblaAndra.SetActive (true);
		speak = ravenDialog;
		}

	IEnumerator waitForFly(float waitTime){
		yield return new WaitForSeconds (waitTime);
		timScript.animWings.SetActive (true);
		gameObject.GetComponent<SpriteRenderer> ().sprite = ravenFly;
		spawn.Play ("birdFlyAwayAnim");
	}
		
	void OnGUI(){
		//GUI.Label(new Rect(790,240,200,190), speak , timScript.style);
		GUI.Label(new Rect(Screen.width/1.7f,Screen.height/3.4f,200,190), speak , timScript.style);
	}

}
