using UnityEngine;
using System.Collections;

public class Tim : MonoBehaviour {
	public string gameState = "";
	public GameObject micVolume;

	//inventory as strings
	ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
		inventory.Add("Rock");
		inventory.Add ("Flower");


	}
	
	// Update is called once per frame
	void Update () {
		checkInventory ();

		print ("gamestate = " + gameState);
		for(int i = 0; i < inventory.Count; i++){
			
		//prints inventory to console
		//print (inventory[i]);
		}
	}

	//checks inventory to determine gameState
	void checkInventory(){

		if(inventory.Contains("Rock") && !inventory.Contains("Flower")){
			gameState = "rock";
		}

		if(inventory.Contains("Rock") && inventory.Contains("Flower")){
			gameState = "rock,flower";
		}
			
	}


}
