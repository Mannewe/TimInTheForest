using UnityEngine;
using System.Collections;

public class Tim : MonoBehaviour {

	public GameObject micVolume;
	GameObject[] moodBar;

	public string gameState = "start";
	public int mood = 0;

	//inventory as strings
	public ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {

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

		for(int i = 0; i < 11; i++){
			moodBar [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < inventory.Count; i++){
			print(inventory[i]);
		}

		MoodChanger ();
		checkInventory ();

		if(Input.GetKeyDown("w")){
			Whisper (true);
		}

		if (Input.GetKeyDown ("s")) {
			Yell (true);
		}

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

	void TimTalk(){
		
	}

	public void Yell(bool yell){
		if(yell == true){
		mood = mood + 3;
		
			if(mood >= 10){
				mood = 10;
			}
		}

		yell = false;
	}


	public void Whisper(bool whisper){
		if(whisper == true){
		mood = mood - 2;

			if(mood <= 0){
				mood = 0;
			}
		}
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

}
