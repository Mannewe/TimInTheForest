using UnityEngine;
using System.Collections;

public class Tim : MonoBehaviour {

	public GameObject micVolume;
	GameObject[] moodBar;
	GameObject pratBubbla;
	Dialog dialog = new Dialog();
	public bool started = false;

	//Animations
	public Animation animScared;

	public ArrayList TimDialogHappy;
	public ArrayList TimDialogScared;
	public ArrayList TimDialogAngry;

	GameObject pinne;
	GameObject Berries;
	GameObject Sword;
	GameObject Bunny;
	GameObject MushroomBad;
	GameObject MushroomGood;
	GameObject Stone1;
	GameObject Stone2;
	GameObject FrogDead;
	GameObject Flower;
	GameObject startbox;
	public GameObject bunnyFollower;

	GUIStyle style = new GUIStyle();
	GUIStyle style2 = new GUIStyle();

	string dialoger;
	string startText = "Tim is lost in the forest, affect his mood by \n screaming or whispering to him and he will do the rest \n \n Press S to start";
	bool speak = false;

	AudioSource scream;
	AudioSource angry;
	AudioSource calm;
	AudioSource[] aSources;

	public string gameState = "Start";
	public int mood = 0;

	//inventory as strings
	public ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
		getDialog ();

		style.fontSize = 20;
		style2.fontSize = 40;

		animScared = gameObject.GetComponent<Animation> ();

		moodBar = new GameObject[11];

		aSources = new AudioSource[3];
		aSources = gameObject.GetComponents<AudioSource> ();

		scream = aSources [0];
		angry = aSources [1];
		calm = aSources [2];

		pinne = GameObject.FindWithTag("Pinne");
		Berries = GameObject.FindWithTag("Bär");
		Sword = GameObject.FindWithTag("Svärd");
		Bunny = GameObject.FindWithTag("Kanin");
		MushroomBad = GameObject.FindWithTag("Flugsvamp");
		MushroomGood = GameObject.FindWithTag("Kantarell");
		Stone1 = GameObject.FindWithTag("Stone1");
		Stone2 = GameObject.FindWithTag("Stone2");
		FrogDead = GameObject.FindWithTag("FrogDead");
		Flower = GameObject.FindWithTag("Flower");
		bunnyFollower = GameObject.FindWithTag ("BunnyFollower");
		startbox = GameObject.FindWithTag ("Startbox");

		pinne.SetActive (false);
		Berries.SetActive (false);
		Sword.SetActive (false);
		Bunny.SetActive (false);
		MushroomBad.SetActive (false);
		MushroomGood.SetActive (false);
		bunnyFollower.SetActive (false);
		Stone1.SetActive (false);
		Stone2.SetActive (false);
		FrogDead.SetActive (false);
		Flower.SetActive (false);

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
		startScreen ();
		if(started == true){
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
	}

	//checks inventory to determine gameState
	void checkInventory(){

		if(inventory.Contains("Stone1")){
			Stone1.SetActive (true);
		}else {
			Stone1.SetActive (false);
		}

		if(inventory.Contains("Stone2")){
			Stone2.SetActive (true);
		}else {
			Stone2.SetActive (false);
		}

		if(inventory.Contains("FrogDead")){
			FrogDead.SetActive (true);
		}else {
			FrogDead.SetActive (false);
		}

		if (inventory.Contains ("Flower")) {
			Flower.SetActive (true);
		} else {
			Flower.SetActive (false);
		}

		if (inventory.Contains ("berries")) {
			Berries.SetActive (true);
		} else {
			Berries.SetActive (false);
		}

		if(inventory.Contains("Sword")){
			Sword.SetActive (true);
		}else {
			Sword.SetActive (false);
		}

		if(inventory.Contains("Bunny")){
			Bunny.SetActive (true);
		}else {
			Bunny.SetActive (false);
		}

		if(inventory.Contains("Stick")){
			pinne.SetActive (true);
		}else {
			pinne.SetActive (false);
		}

		if(inventory.Contains("MushroomBad")){
			MushroomBad.SetActive (true);
		}else {
			MushroomBad.SetActive (false);
		}

		if(inventory.Contains("MushroomGood")){
			MushroomGood.SetActive (true);
		}else {
			MushroomGood.SetActive (false);
		}
			
	}

	public void TimTalk(){
		
		if(mood <= 3){
			dialoger = TimDialogHappy [Random.Range(0,1)].ToString ();
			//playAudio calm
			calm.Play ();
			if(!animScared.isPlaying){
				animScared.Play("animCalm");
			}
		}

		if(mood >= 4 && mood <= 7){
			dialoger = TimDialogScared [Random.Range(0,3)].ToString ();
			//playAudio scared
			if (!animScared.isPlaying) {
				animScared.Play ("animScared");
			}
			scream.Play ();
		}

		if(mood >= 8){
			dialoger = TimDialogAngry [Random.Range(0,2)].ToString ();
			//playAudio angry

			angry.Play ();
			if (!animScared.isPlaying) {
				animScared.Play ("animAngry");
			}
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

		//playAudio
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
		GUI.Label(new Rect(300,200,200,190), dialoger , style);
		}
		if(gameState == "Start"){
			GUI.Box (new Rect(Screen.width/2 - 450,100,200,200), startText, style2);
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

	void startScreen(){
		if(Input.GetKeyDown("s")){
			startbox.SetActive (false);
			started = true;
			gameState = "Berries";

		}
	}

	IEnumerator timeToSpeak(float waitTime){
		yield return new WaitForSeconds (waitTime);
		pratBubbla.SetActive (false);
		speak = false;
	}
}
