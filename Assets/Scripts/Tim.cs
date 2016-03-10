using UnityEngine;
using System.Collections;

public class Tim : MonoBehaviour {

	public GameObject micVolume;
	GameObject[] moodBar;
	GameObject pratBubbla;
	Dialog dialog = new Dialog();
	public bool started = false;
	public bool moodChanged = false;

	public GameObject leftLeg;
	public GameObject rightLeg;
	public GameObject leftArm;
	public GameObject rightArm;

	public Animation leftLegAnim;
	public Animation rightLegAnim;
	public Animation rightArmAnim;
	public Animation leftArmAnim;

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

	GameObject scroller1;
	GameObject scroller2;
	GameObject scroller3;

	ScrollingBackground scroller1Script;
	ScrollingBackground scroller2Script;
	ScrollingBackground scroller3Script;

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

		leftLeg = GameObject.FindWithTag ("LeftLeg");
		rightLeg = GameObject.FindWithTag ("RightLeg");
		leftArm = GameObject.FindWithTag ("LeftArm");
		rightArm = GameObject.FindWithTag ("RightArm");

		leftArmAnim = leftArm.GetComponent<Animation> ();
		leftLegAnim = leftLeg.GetComponent<Animation> ();
		rightArmAnim = rightArm.GetComponent<Animation> ();
		rightLegAnim = rightLeg.GetComponent<Animation> ();

		style.fontSize = 20;
		style2.fontSize = 40;

		animScared = gameObject.GetComponent<Animation> ();

		moodBar = new GameObject[11];

		aSources = new AudioSource[3];
		aSources = gameObject.GetComponents<AudioSource> ();

		scream = aSources [0];
		angry = aSources [1];
		calm = aSources [2];

		scroller1 = GameObject.FindWithTag ("scroller1");
		scroller2 = GameObject.FindWithTag ("scroller2");
		scroller3 = GameObject.FindWithTag ("scroller3");

		scroller1Script = scroller1.GetComponent<ScrollingBackground> ();
		scroller2Script = scroller2.GetComponent<ScrollingBackground> ();
		scroller3Script = scroller3.GetComponent<ScrollingBackground> ();

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
		print (scroller1Script.speed);
		getDialog ();
		startScreen ();
		if(started == true){
		print (dialoger);
		//TimTalk ();
		for(int i = 0; i < inventory.Count; i++){
			print(inventory[i]);
		}

		MoodChanger ();
		checkInventory ();

			if(animScared.IsPlaying("animScared")){
				leftArmAnim.Play ("ScaredArmLeft");
				rightArmAnim.Play ("ScaredArmRight");
			}

			if(animScared.IsPlaying("animAngry")){
				leftArmAnim.Play ("AngryArmLeft");
				rightArmAnim.Play ("AngryArmRight");
			}

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

		if(mood == 0){
			scroller1Script.speed = 0f;
			scroller2Script.speed = 0f;
			scroller3Script.speed = 0f;
		}
		if(mood <= 3 && mood >0){
			scroller1Script.speed = 0.2f;
			scroller2Script.speed = 0.5f;
			scroller3Script.speed = 1.5f;
			dialoger = TimDialogHappy [Random.Range(0,3)].ToString ();
			//playAudio calm
			calm.Play ();
			if(!animScared.isPlaying){
				animScared.Play("animCalm");
			}
		}

		if(mood >= 4 && mood <= 7){
			scroller1Script.speed = 0.2f;
			scroller2Script.speed = 0.5f;
			scroller3Script.speed = 1.5f;
			dialoger = TimDialogScared [Random.Range(0,3)].ToString ();
			//playAudio scared
			if (!animScared.isPlaying) {
				animScared.Play ("animScared");
			}
			scream.Play ();
		}

		if(mood >= 8 && mood < 10){
			scroller1Script.speed = 0.2f;
			scroller2Script.speed = 0.5f;
			scroller3Script.speed = 1.5f;
			dialoger = TimDialogAngry [Random.Range(0,3)].ToString ();
			//playAudio angry
			angry.Play ();
			if (!animScared.isPlaying) {
				animScared.Play ("animAngry");
			}
		}
		if (mood == 10) {
			scroller1Script.speed = 0f;
			scroller2Script.speed = 0f;
			scroller3Script.speed = 0f;
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

		if(gameState == "Bunny1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//before meeting object
			if(scroller1Script.speed != 0){
			//Dialog
			//happy
			TimDialogHappy.Add ("Come here little bunny, have some berries.");
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			//scared
			TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
			}
		}

		if (gameState == "Stones1") {

			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("I'll pick up these beautiful stones");
				TimDialogScared.Add ("I might need these?");
				TimDialogAngry.Add ("If i pick up these stupid stones i can thow them on something");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Wait, didn’t we live across each other freshmen year? Oh sorry, you’re just a stone. My bad.");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("I better take these stones in case I run into trouble.");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("These stones could be handy in a fight.");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		
		}

		if(gameState == "Raven1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();


			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
		if (scroller1Script.speed != 0) {
			TimDialogHappy.Add ("You look like you know what’s up. Do you have any tips for me?");
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			//scared
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
		}
		}

		if(gameState == "Bunny2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();


			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
		if (scroller1Script.speed != 0) {
			TimDialogHappy.Add ("I’m giving you the silent treatment. Damn it, I wasn’t supposed to speak.");
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			//scared
			TimDialogScared.Add ("I’m only slightly scared of you. But don’t tell anyone.");
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("Die stupid bunny!");
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
		}
		}

		if(gameState == "Stick1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
		if (scroller1Script.speed != 0) {
			TimDialogHappy.Add ("Oh, what a pretty stick!");
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			//scared
			TimDialogScared.Add ("I wonder who’s stick this is. Maybe some evil monster dropped it.");
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("I could really use this stick in case I need to fight someone. Or something. ");
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
		}
		}

		if(gameState == "Berries"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
		if (scroller1Script.speed != 0) {
			TimDialogHappy.Add ("Mybe i can find som tasty berries?");
			TimDialogHappy.Add ("What a beautiful place");
			TimDialogHappy.Add ("Dum dubidumbidum dum blalalala singiling ding..");
			//scared
			TimDialogScared.Add ("Aah, this place gives me the creeps.");
			TimDialogScared.Add ("AAAAAAh! Did i just hear a wolf? i need to get out of here");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("I hate this dumb forest place, i will ruin it");
			TimDialogAngry.Add ("Stupid flower, stupid rock, stupid trees, stupid stupid STUPIID");
			TimDialogAngry.Add ("");
		}
		}

		if(gameState == "Stick2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
		if (scroller1Script.speed != 0) {
			TimDialogHappy.Add ("Oh, what a pretty stick!");
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			//scared
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("Smash the stick!");
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
		}
		}

		if(gameState == "Raven2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
		if (scroller1Script.speed != 0) {
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			TimDialogHappy.Add ("");
			//scared
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			TimDialogScared.Add ("");
			//angry
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
			TimDialogAngry.Add ("");
		}
		}

		if(gameState == "Frog1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Here you go Mr Frog King sir, have a bunny!");
				TimDialogHappy.Add ("Who are you? Do you have a daughter I can marry?");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Frog2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Who are you? Do you have a daughter I can marry?");
				TimDialogHappy.Add ("Here you go Mr Frog King sir, have a bunny!");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Frog3"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Who are you? Do you have a daughter I can marry?");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Frog4"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Take this mushroom.");
				TimDialogHappy.Add ("Who are you? Do you have a daughter I can marry?");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Frog5"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Who are you? Do you have a daughter I can marry?");
				TimDialogHappy.Add ("You look hungry. Take this dead rabbit.");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("Prepare to die!");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Mushroom1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Mushrooms! Yum!");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("Disgusting mushrooms.");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Flower1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();
		}

		if(gameState == "Flower2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");


				//scared

				TimDialogScared.Add (" ");
				TimDialogScared.Add (" ");
				TimDialogScared.Add (" ");
				//angry
				TimDialogAngry.Add (" ");
				TimDialogAngry.Add (" ");
				TimDialogAngry.Add (" ");
			}


		}

		if(gameState == "Sword1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("This is a good sword.");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Sword2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("This is a good sword.");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Sword3"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("This is a good sword.");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
			}

		if(gameState == "Dragon1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Are you a flower guy? You look like a flower guy.");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("Prepare to die!");
				TimDialogAngry.Add ("Wow, you have a nasty breath. Try brushing your teeth sometime.");
				TimDialogAngry.Add ("Eat my stick!");
			}
		}

		if(gameState == "Dragon2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("You look like something out of my favorite cartoon.");
				TimDialogHappy.Add ("Let’s be friend. I can make you a bead necklace if you accept.");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("Prepare to die!");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
		}

		if(gameState == "Dragon3"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

			//Dialog
			//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("Want a flower? I just got it, actually.");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("Prepare to die!");
				TimDialogAngry.Add ("I will kill you with my bare hands!");
				TimDialogAngry.Add ("");
			}
				}

				if(gameState == "Dragon4"){
					TimDialogHappy.Clear ();
					TimDialogScared.Clear ();
					TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

					//Dialog
					//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("You look like you need a friend. How about it?");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("I challenge you, insect!");
				TimDialogAngry.Add ("");
				TimDialogAngry.Add ("");
			}
				}

				if(gameState == "Dragon5"){
					TimDialogHappy.Clear ();
					TimDialogScared.Clear ();
					TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.speed == 0) {
				TimDialogHappy.Add ("Come here little bunny, have some berries.");
				TimDialogScared.Add ("Hi, are you running around lost in a forest? I can relate.");
				TimDialogAngry.Add ("");
			}

					//Dialog
					//happy
			if (scroller1Script.speed != 0) {
				TimDialogHappy.Add ("You look starved. Care for some frog’s legs?");
				TimDialogHappy.Add ("");
				TimDialogHappy.Add ("");
				//scared
				TimDialogScared.Add ("Don’t be mad, I’m sure we can work things out.");
				TimDialogScared.Add ("");
				TimDialogScared.Add ("");
				//angry
				TimDialogAngry.Add ("I’m not scared of you, dragon or snake or whatever you are!");
				TimDialogAngry.Add ("Prepare to die, hellspawn!");
				TimDialogAngry.Add ("");
			}
		}

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
