using UnityEngine;
using System.Collections;

public class Tim : MonoBehaviour {

	public GameObject micVolume;
	GameObject[] moodBar;
	GameObject pratBubbla;
	Dialog dialog = new Dialog();
	public bool started = false;
	public bool moodChanged = false;

	Animation animStartSign;
	GameObject startSign;

	public Sprite timHappy;
	public Sprite timScared;
	public Sprite timAngry;

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
	public Animation rockThrow;
	public Animation throwDeadRabbit;
	public Animation throwBadMushroom;
	public Animation throwGoodMushroom;
	public Animation bunnyAnim;
	public Animation wings;
	public Animation birdFly;
	public Animation deadFrog;
	public Animation throwFlower;

	//Dialog lists
	public ArrayList TimDialogHappy;
	public ArrayList TimDialogScared;
	public ArrayList TimDialogAngry;

	//gameObjects
	GameObject pinne;
	GameObject s;
	GameObject Sword;
	GameObject Bunny;
	GameObject MushroomBad;
	GameObject MushroomGood;
	GameObject Stone1;
	GameObject Stone2;
	GameObject FrogDead;
	GameObject Flower;
	GameObject startbox;
	public GameObject pratbubblaAndra;
	public GameObject pratbubblaAndra2;
	public GameObject animBird;
	public GameObject animWings;

	//animationObjects
	public GameObject animSword;
	public GameObject bunnyFollower;
	public GameObject animRock;
	public GameObject animStick;
	public GameObject animDeadRabbit;
	public GameObject animKantarell;
	public GameObject animFlugsvamp;
	public GameObject animDeadFrog;
	public GameObject animFlower;

	//Background
	GameObject scroller1;
	GameObject scroller2;
	GameObject scroller3;

	ScrollingBackground scroller1Script;
	ScrollingBackground scroller2Script;
	ScrollingBackground scroller3Script;

	//onGUI
	string dialoger;
	string startText = "Tim is lost in the forest, affect his mood by \n screaming or whispering to him and he will do the rest \n \n Press S to start";

	public GUIStyle style = new GUIStyle();
	GUIStyle style2 = new GUIStyle();

	//Is Tim speaking?
	bool speak = false;

	//Audiosources
	AudioSource scream;
	AudioSource angry;
	AudioSource calm;
	AudioSource[] aSources;

	//GameState
	public string gameState = "Start";

	//Mood
	public int mood = 0;

	//inventory as strings
	public ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {

		leftLeg = GameObject.FindWithTag ("LeftLeg");
		rightLeg = GameObject.FindWithTag ("RightLeg");
		leftArm = GameObject.FindWithTag ("LeftArm");
		rightArm = GameObject.FindWithTag ("RightArm");

		pratbubblaAndra = GameObject.FindWithTag ("pratbubblaAndra");
		pratbubblaAndra2 = GameObject.FindWithTag ("pratbubblaAndra2");

		leftArmAnim = leftArm.GetComponent<Animation> ();
		leftLegAnim = leftLeg.GetComponent<Animation> ();
		rightArmAnim = rightArm.GetComponent<Animation> ();
		rightLegAnim = rightLeg.GetComponent<Animation> ();

		style.fontSize = 20;
		style2.fontSize = 40;

		animFlower = GameObject.FindWithTag ("animFlower");
		animDeadFrog = GameObject.FindWithTag ("animDeadFrog");
		animScared = gameObject.GetComponent<Animation> ();
		deadFrog = animDeadFrog.GetComponent < Animation> ();
		throwFlower = animFlower.GetComponent<Animation> ();
		animRock = GameObject.FindWithTag ("animRock");
		animSword = GameObject.FindWithTag ("animSword");
		animStick = GameObject.FindWithTag ("animStick");
		animDeadRabbit = GameObject.FindWithTag ("animDeadRabbit");
		animFlugsvamp = GameObject.FindWithTag ("animFlugsvamp");
		animKantarell = GameObject.FindWithTag ("animKantarell");
		animWings = GameObject.FindWithTag ("animWings");

		wings = animWings.GetComponent<Animation> ();

		throwBadMushroom = animFlugsvamp.GetComponent<Animation> ();
		throwGoodMushroom = animKantarell.GetComponent<Animation> ();
		rockThrow = animRock.GetComponent<Animation> ();
		throwDeadRabbit = animDeadRabbit.GetComponent<Animation> ();


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
		s = GameObject.FindWithTag("Bär");
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
		animStartSign = startbox.GetComponent<Animation> ();
		bunnyAnim = bunnyFollower.GetComponent<Animation> ();

		pinne.SetActive (false);
		s.SetActive (false);
		Sword.SetActive (false);
		Bunny.SetActive (false);
		MushroomBad.SetActive (false);
		MushroomGood.SetActive (false);
		bunnyFollower.SetActive (false);
		Stone1.SetActive (false);
		Stone2.SetActive (false);
		FrogDead.SetActive (false);
		Flower.SetActive (false);
		pratbubblaAndra.SetActive (false);
		pratbubblaAndra2.SetActive (false);
		animWings.SetActive (false);

		animSword.SetActive (false);
		animStick.SetActive (false);

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

		animStartSign.Play ("startSign");
	}
	
	// Update is called once per frame
	void Update () {
		getDialog ();
//		print (scroller1Script.speed);
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

			if(animScared.IsPlaying("Killstuff")){
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
			s.SetActive (true);
		} else {
			s.SetActive (false);
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

		if(mood == 0 && scroller1Script.running == true){
			gameObject.GetComponent<SpriteRenderer> ().sprite = timHappy;
			dialoger = "Wow, this place is really beautiful. \n I think I’ll stay here all day.";
			scroller1Script.speed = 0f;
			scroller2Script.speed = 0f;
			scroller3Script.speed = 0f;
			calm.Play ();
			if(!animScared.isPlaying){
				animScared.Play("animCalm");
			}
		} else if(mood == 0){
			gameObject.GetComponent<SpriteRenderer> ().sprite = timHappy;
			dialoger = TimDialogHappy [0].ToString ();
			calm.Play ();
			if(!animScared.isPlaying){
				animScared.Play("animCalm");
			}
		}
		if(mood <= 3 && mood >0){
			gameObject.GetComponent<SpriteRenderer> ().sprite = timHappy;
			dialoger = TimDialogHappy [0].ToString ();
			scroller1Script.speed = 0.2f;
			scroller2Script.speed = 0.5f;
			scroller3Script.speed = 1.5f;
			//playAudio calm
			calm.Play ();
			if(!animScared.isPlaying){
				animScared.Play("animCalm");
			}
		}

		if(mood >= 4 && mood <= 7){
			gameObject.GetComponent<SpriteRenderer> ().sprite = timScared;
			dialoger = TimDialogScared [0].ToString ();
			scroller1Script.speed = 0.2f;
			scroller2Script.speed = 0.5f;
			scroller3Script.speed = 1.5f;
			//playAudio scared
			if (!animScared.isPlaying) {
				animScared.Play ("animScared");
			}
			scream.Play ();
		}

		if(mood >= 8 && mood < 10){
			gameObject.GetComponent<SpriteRenderer> ().sprite = timAngry;
			dialoger = TimDialogAngry [0].ToString ();
			scroller1Script.speed = 0.2f;
			scroller2Script.speed = 0.5f;
			scroller3Script.speed = 1.5f;
			//playAudio angry
			angry.Play ();
			if (!animScared.isPlaying) {
				animScared.Play ("animAngry");
			}
		}
		if (mood == 10 && scroller1Script.running == true) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = timAngry;
			dialoger = "Stop yelling at me! \n I won’t go any further \n until you stop yelling!";
			scroller1Script.speed = 0f;
			scroller2Script.speed = 0f;
			scroller3Script.speed = 0f;
			angry.Play ();
			if (!animScared.isPlaying) {
				animScared.Play ("animAngry");
			}
		} else if(mood == 10){
			gameObject.GetComponent<SpriteRenderer> ().sprite = timAngry;
			dialoger = TimDialogAngry [0].ToString ();
			angry.Play ();
			if (!animScared.isPlaying) {
				animScared.Play ("animAngry");
			}
		}
	}

	public void Yell(bool yell){
		getDialog ();
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
		getDialog ();
		if(whisper == true){
		speak = true;
		pratBubbla.SetActive (true);
		mood = mood - 2;

			if(mood <= 0){
				mood = 0;
			}
		}
		TimTalk ();
		//DELAY UNTIL YOU CAN SPEAK AGAIN
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
			//GUI.Label(new Rect(300,200,200,190), dialoger , style);
			GUI.Label(new Rect(Screen.width/4.5f,Screen.height/4f,200,190), dialoger , style);
		}
//		if(gameState == "Start"){
//			GUI.Box (new Rect(Screen.width/2 - 450,100,200,200), startText, style2);
//		}
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
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Come here little bunny, \nhave some berries.");
				TimDialogScared.Add ("Hi, are you running around \nlost in a forest? I can relate.");
				TimDialogAngry.Add ("I’m giving you the silent treatment. \nDamn it, I wasn’t supposed to speak.");
			}

			//before meeting object
			if(scroller1Script.running == true){
				TimDialogHappy.Add("If only I had someone to \nshare these berries with.");
				TimDialogScared.Add("I’m not in the mood to eat \nall of these berries by myself.");
				TimDialogAngry.Add("Berries are not useful in any\n situation, my mother told me so.");
			}
		}

		if (gameState == "Stones1") {

			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Wait, didn’t we live across \neach other freshmen year? Oh sorry, \nyou’re just a stone. My bad.");
				TimDialogHappy.Add("These stones would make a \nbeautiful necklace.");
				TimDialogScared.Add ("I better take these stones \nin case I run into trouble.");
				TimDialogScared.Add("Oh, I could make some skipping \nrocks with these… If only I could find \nmy way out of here…");
				TimDialogAngry.Add ("These stones could be\n handy in a fight.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("All the single ladies.. all \nthe single ladies…");
				TimDialogScared.Add("Grass is fun, but trees \nare a richer experience");
				TimDialogAngry.Add("What is life?");
			}
		
		}

		if(gameState == "Raven1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();


			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("You look like you know what’s up. \nDo you have any tips for me?");
				TimDialogScared.Add ("Where did that raven come from!?");
				TimDialogAngry.Add ("That’s it. A bird. You know what, \nthis is just too much. I hate birds.");
			}

			//Dialog
			//happy
		if (scroller1Script.running == true) {
				TimDialogHappy.Add("I could do this all day long. \nIf only my legs would work properly.");
				TimDialogScared.Add ("Birds aren’t very smart \ncreatures, right?");
				TimDialogAngry.Add("I’ve never really been \na bird person.");
		}
		}

		if(gameState == "Bunny2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();


			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("I’m giving you the silent treatment.\n Damn it, I wasn’t supposed to speak.");
				TimDialogScared.Add ("I’m only slightly scared of you. \n But don’t tell anyone.");
				TimDialogAngry.Add ("Die stupid bunny!");
			}

			//Dialog
			//happy
		if (scroller1Script.running == true) {
				TimDialogHappy.Add("All the single ladies.. all \nthe single ladies…");
				TimDialogScared.Add("I wonder if there are \n wolves in this forest.");
				TimDialogAngry.Add("How the hell do I get home!?");
		}
		}

		if(gameState == "Stick1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Oh, what a pretty stick!");
				TimDialogHappy.Add("Ah, a magic wand!!");
				TimDialogScared.Add ("I wonder who’s stick this is. \n Maybe some evil monster dropped it.");
				TimDialogAngry.Add ("I could really use this stick \n in case I need to fight someone. \nOr something. ");
			}

			//Dialog
			//happy
		if (scroller1Script.running == true) {
				TimDialogHappy.Add("I like turtles.");
				TimDialogScared.Add("I had pancakes for dinner \n last Saturday.");
				TimDialogAngry.Add("I feel like smashing something.");
		}
		}

		if(gameState == "Berries"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("These berries look tasty.");
				TimDialogScared.Add ("What if these berries \n are poisonous?");
				TimDialogAngry.Add ("I don’t want any \n stupid berries. ");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I wonder if I can find \n some mushrooms while I’m here.");
				TimDialogScared.Add("I’m sixty percent sure I’m \n lost in here. Okay, eighty percent.");
				TimDialogAngry.Add("Stupid forest, why did \n I even go in here?");
		}
		}

		if(gameState == "Stick2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Oh, what a pretty stick!");
				TimDialogScared.Add("What if this stick has thorns?");
				TimDialogAngry.Add ("Smash the stick!");
			}

			//Dialog
			//happy
		if (scroller1Script.running == true) {
				TimDialogHappy.Add("What should I eat for dinner?");
				TimDialogScared.Add ("I need weapons in case \n something will try to kill me");
				TimDialogAngry.Add("I feel like smashing something.");
		}
		}

		if(gameState == "Raven2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("A raven! I want to bathe\n in your feathers, but then again \nI don’t have my glasses on me.");
				TimDialogScared.Add ("Where did that raven come from!?");
				TimDialogAngry.Add ("Stupid raven, get out of here!");
			}

			//Dialog
			//happy
		if (scroller1Script.running == true) {
				TimDialogHappy.Add("I like turtles.");
				TimDialogScared.Add ("Was that a wolf howling!?");
				TimDialogAngry.Add("Father always says he wants to \nhave a stuffed animal head hanging \non the wall… I should keep this.");
		}
		}

		if(gameState == "Frog1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Here you go Mr Frog King sir, \nhave a bunny!");
				TimDialogScared.Add ("Wow, you’re tall. You \nmust play basketball.");
				TimDialogAngry.Add ("I challenge you to a stick fight!");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("How do trees get on the \ninternet? They log in!");
				TimDialogScared.Add("What kind of flower grows \non your face? Tulips!");
				TimDialogAngry.Add ("I'm going to smack this \nstick into something");
			}
		}

		if(gameState == "Frog2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Here you go Mr Frog King sir, \nhave a bunny!");
				TimDialogScared.Add ("A dead frog wouldn’t be \nmy first choice, but the diet I’m \non require a lot protein.");
				TimDialogAngry.Add ("I was thinking of saying a \npunchline, but a punch will do.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("How do trees get on the \ninternet? They log in!");
				TimDialogScared.Add("I should hug a tree.");
				TimDialogAngry.Add("Was that a wolf howling!?");
			}
		}

		if(gameState == "Frog3"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Who are you? Do you have \na daughter I can marry?");
				TimDialogScared.Add ("At least it’s not raining.");
					TimDialogAngry.Add ("Not again…");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("My god, this forest reminds \nme of an Adele song.");
				TimDialogScared.Add("I should hug a tree.");
				TimDialogAngry.Add("What time is it?");
			}
		}

		if(gameState == "Frog4"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Take this mushroom.");
				TimDialogScared.Add ("What a shiny hat you’ve got!");
				TimDialogAngry.Add ("So I found this sweet \nmushroom… do you want it?");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I could do this all day long. \nIf only my legs would work properly.");
				TimDialogScared.Add("I should hug a tree.");
				TimDialogAngry.Add("What kind of flower grows \non your face? Tulips!");
			}
		}

		if(gameState == "Frog5"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("You look hungry. Take \nthis dead rabbit.");
				TimDialogScared.Add ("I had warts like that once, \nit was not pretty.");
				TimDialogAngry.Add ("Prepare to die!");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I had pancakes for dinner \nlast Saturday.");
				TimDialogScared.Add("What is life?");
				TimDialogAngry.Add("Dang it! I’m so tired \nof this forest.");
			}
		}

		if(gameState == "Mushroom1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Mushrooms! Yum!");
				TimDialogHappy.Add("Yes, finally found some mushrooms!");
				TimDialogScared.Add ("I sure hope these mushrooms \naren’t poisonous.");
				TimDialogAngry.Add ("Disgusting mushrooms.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I like turtles.");
				TimDialogScared.Add("Who’s there!?");
				TimDialogAngry.Add("What time is it?");
			}
		}

		if(gameState == "Flower1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Such a pretty flower. ");
				TimDialogScared.Add ("Gosh, I really hope I’m not \nallergic to this flower.");
				TimDialogAngry.Add ("I’ve seen prettier flowers, \nbut I guess it’ll do.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I like turtles.");
				TimDialogScared.Add("That frog wasn’t scary at all.");
				TimDialogAngry.Add("What time is it?");
			}

		}

		if(gameState == "Flower2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Such a pretty flower. ");
				TimDialogScared.Add ("How will I survive the night?");
				TimDialogAngry.Add ("I’ve seen prettier flowers, \nbut I guess it’ll do.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("That was by far the most friendly \nfrog I’ve ever met. Today.");
				TimDialogScared.Add("I wish I was a turtle.");
				TimDialogAngry.Add("How big is this forest!?");
			}


		}

		if(gameState == "Sword1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("This is a good sword.");
				TimDialogScared.Add("I like cats… oh, I also like tacos.");
				TimDialogAngry.Add("A sword! Weapon of murder. \nSwords makes my blood pump with anger.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I’ve never felt so alive before.");
				TimDialogScared.Add("Looks like the frog dropped something.");
				TimDialogAngry.Add("Sometimes, violence is the only \noption. Just ask Wolverine from X-Men.");
			}
		}

		if(gameState == "Sword2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("This is a good sword.");
				TimDialogScared.Add("Looks like the frog dropped something.");
				TimDialogAngry.Add("A sword! Weapon of murder. \nSwords makes my blood pump with anger.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I wish I was a turtle.");
				TimDialogScared.Add("Looks like the frog dropped something.");
				TimDialogAngry.Add("Didn’t your mother teach you\n not to eat spotted mushrooms!?");
			}
		}

		if(gameState == "Sword3"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("This is a good sword.");
				TimDialogScared.Add("Looks like the raven dropped something.");
				TimDialogAngry.Add("A sword! Weapon of murder. \nSwords makes my blood pump with anger.");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add("I like cats… oh, I also like tacos.");
				TimDialogScared.Add("I don’t like things with wings.");
				TimDialogAngry.Add("What time is it?");
			}
			}

		if(gameState == "Dragon1"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add("Take this flower, it smells pretty good.");
				TimDialogScared.Add("Wow, you have a nasty breath. \nTry brushing your teeth sometime.");
				TimDialogAngry.Add ("Eat my stick!");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add ("My god, this forest reminds\n me of an Adele song.");
					TimDialogScared.Add("Was that a wolf howling!?");
					TimDialogAngry.Add ("Holy fishsticks!");
			}
		}

		if(gameState == "Dragon2"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("Let’s be friends. I can make you \na bead necklace if you accept.");
				TimDialogScared.Add("I can’t decide if I’m scared of you or not!");
				TimDialogAngry.Add ("Prepare to die!");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add ("This place look like something \nout of my favorite cartoon.");
				TimDialogScared.Add("I had pancakes for dinner last Saturday.");
				TimDialogAngry.Add("How the hell do I get home!?");
			}
		}

		if(gameState == "Dragon3"){
			TimDialogHappy.Clear ();
			TimDialogScared.Clear ();
			TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add("Do you want a flower? \nI just got one, actually.");
				TimDialogScared.Add("GHAAA, a snake!");
				TimDialogAngry.Add ("I will kill you with my bare hands!");
			}

			//Dialog
			//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add ("I wish I was a turtle.");
				TimDialogScared.Add("Was that a wolf howling!?");
				TimDialogAngry.Add("How the hell do I get home!?");
			}
				}

				if(gameState == "Dragon4"){
					TimDialogHappy.Clear ();
					TimDialogScared.Clear ();
					TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("You look like you need \na friend. How about it?");
				TimDialogScared.Add ("Don’t be mad, I’m sure \nwe can work things out.");
				TimDialogAngry.Add ("I challenge you, insect!");
			}

					//Dialog
					//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add ("I like cats… oh, I also like tacos.");
				TimDialogScared.Add("How will i survive the night?");
				TimDialogAngry.Add("How the hell do I get home!?");
			}
				}

				if(gameState == "Dragon5"){
					TimDialogHappy.Clear ();
					TimDialogScared.Clear ();
					TimDialogAngry.Clear ();

			//When meeting object
			if (scroller1Script.running == false) {
				TimDialogHappy.Add ("You look starved. Care for \nsome frog’s legs?");
				TimDialogScared.Add ("I’m not scared of you, dragon \nor snake or whatever you are! \nAt least, I don’t think I am.");
					TimDialogAngry.Add ("Prepare to die, hell-spawn!");
			}

					//Dialog
					//happy
			if (scroller1Script.running == true) {
				TimDialogHappy.Add ("This frog is quite heavy.");
				TimDialogScared.Add("Hmm… What did the raven \nsay about frog’s legs again? \nBetter keep the frog.");
					TimDialogAngry.Add("How big is this forest!?");
			}
		}

	}

	void startScreen(){
		if(Input.GetKeyDown("s")){
			//startbox.SetActive (false);
			animStartSign.Play ("endSign");
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