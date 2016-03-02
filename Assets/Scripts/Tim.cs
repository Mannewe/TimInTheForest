using UnityEngine;
using System.Collections;

public class Tim : MonoBehaviour {

	public GameObject micVolume;
	GameObject[] moodBar;
	GameObject pratBubbla;
	Dialog dialog = new Dialog();

	public ArrayList TimDialogHappy;
	public ArrayList TimDialogScared;
	public ArrayList TimDialogAngry;

	GUIStyle style = new GUIStyle();

	string dialoger;
	bool speak = false;

	public string gameState = "start";
	public int mood = 0;

	//inventory as strings
	public ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
		getDialog ();

		style.fontSize = 30;

		moodBar = new GameObject[11];

		moodBar [0] = GameObject.FindWithTag ("0");
		moodBar [1] = GameObject.FindWithTag ("1");
		moodBar [2] = GameObject.FindWithTag ("2");
		moodBar [3] = GameObject.FindWithTag ("3");
		moodBar [4] = GameObject.FindWithTag ("4");
		moodBar [5] = GameObject.FindWithTag ("5");
		moodBar [6] = GameObject.FindWithTag ("6");
		moodBar [7] = GameObject.FindWithTag ("7");
		moodBar [8] = GameObject.FindWithTag ("8");
		moodBar [9] = GameObject.FindWithTag ("9");
		moodBar [10] = GameObject.FindWithTag ("10");

		pratBubbla = GameObject.FindWithTag ("pratbubbla");
		pratBubbla.SetActive (false);

		for(int i = 0; i < 11; i++){
			moodBar [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		print (dialoger);
		//TimTalk ();
		for(int i = 0; i < inventory.Count; i++){
			print(inventory[i]);
		}

		MoodChanger ();
		checkInventory ();

//		if(Input.GetKeyDown("w")){
//			Whisper (true);
//		}
//
//		if (Input.GetKeyDown ("s")) {
//			Yell (true);
//		}

//		if(micVolume.GetComponent<MicrophoneInput>().loudness > 1){
//			Whisper (true);
//		}
//
//		if (micVolume.GetComponent<MicrophoneInput>().loudness > 3) {
//			Yell (true);
//		}

		print ("gamestate = " + gameState);

	}

	//checks inventory to determine gameState
	void checkInventory(){

		if(inventory.Contains("Rock") && !inventory.Contains("Flower")){
			//gameState = "rock";
		}

		if(inventory.Contains("Rock") && inventory.Contains("Flower")){
			//gameState = "rock,flower";
		}
			
	}

	public void TimTalk(){
		
		if(mood <= 3){
			dialoger = TimDialogHappy [0].ToString ();
		}

		if(mood >= 4 && mood <= 7){
				dialoger = TimDialogScared [0].ToString ();

		}

		if(mood >= 8){
				dialoger = TimDialogAngry [0].ToString ();
		
		}
	}

	public void Yell(bool yell){
		if(yell == true){
		speak = true;
		pratBubbla.SetActive (true);
		mood = mood + 3;
		
			if(mood >= 10){
				mood = 10;
			}
		}
		TimTalk ();
		StartCoroutine (timeToSpeak(4f));
		yell = false;
	}


	public void Whisper(bool whisper){
		if(whisper == true){
		speak = true;
		pratBubbla.SetActive (true);
		mood = mood - 2;

			if(mood <= 0){
				mood = 0;
			}
		}
		TimTalk ();
		StartCoroutine (timeToSpeak(4f));
		whisper = false;
	}

	public void MoodChanger(){
		if(mood == 0){
			moodBar [0].SetActive (true);
		}else {
			moodBar [0].SetActive (false);
		}

		if(mood == 1){
			moodBar [1].SetActive (true);
		}else {
			moodBar [1].SetActive (false);
		}

		if(mood == 2){
			moodBar [2].SetActive (true);
		}else {
			moodBar [2].SetActive (false);
		}

		if(mood == 3){
			moodBar [3].SetActive (true);
		}else {
			moodBar [3].SetActive (false);
		}

		if(mood == 4){
			moodBar [4].SetActive (true);
		}else {
			moodBar [4].SetActive (false);
		}

		if(mood == 5){
			moodBar [5].SetActive (true);
		}else {
			moodBar [5].SetActive (false);
		}

		if(mood == 6){
			moodBar [6].SetActive (true);
		}else {
			moodBar [6].SetActive (false);
		}

		if(mood == 7){
			moodBar [7].SetActive (true);
		}else {
			moodBar [7].SetActive (false);
		}

		if(mood == 8){
			moodBar [8].SetActive (true);
		}else {
			moodBar [8].SetActive (false);
		}

		if (mood == 9) {
			moodBar [9].SetActive (true);
		} else {
			moodBar [9].SetActive (false);
		}

		if(mood == 10){
			moodBar [10].SetActive (true);
		}else {
			moodBar [10].SetActive (false);
		}

	}

	void OnGUI(){
		if(speak == true){
		GUI.Label(new Rect(330,200,200,190), dialoger , style);
		}
	}

	void getDialog(){
		TimDialogHappy = new ArrayList ();
		TimDialogScared = new ArrayList ();
		TimDialogAngry = new ArrayList ();

		TimDialogHappy.Add ("This forest is beautiful."); // happy
		TimDialogHappy.Add ("Where are the mushrooms?"); // happy
		TimDialogScared.Add ("I wonder if there are \n wolves in this forest."); // scared
		TimDialogScared.Add ("I want to go home."); // scared
		TimDialogScared.Add ("I have a feeling \n something’s watching me."); // scared
		TimDialogScared.Add ("Aaah! Oh, it was just \n a butterfly."); // scared
		TimDialogAngry.Add ("What am I doing here?"); // angry
		TimDialogAngry.Add ("That flower looks stupid."); // angry
		TimDialogAngry.Add ("I really want to punch something."); // angry
	}

	IEnumerator timeToSpeak(float waitTime){
		yield return new WaitForSeconds (waitTime);
		pratBubbla.SetActive (false);
		speak = false;
	}
}
