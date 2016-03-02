using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
	
	public ArrayList TimDialogHappy;
	public ArrayList TimDialogScared;
	public ArrayList TimDialogAngry;
	public ArrayList otherDialog = new ArrayList ();

	// Use this for initialization
	void Start () {
		TimDialogHappy = new ArrayList ();
		TimDialogScared = new ArrayList ();
		TimDialogAngry = new ArrayList ();

		//TimDialog.Add ("I haven’t met you before, who you are?”");
		//TimDialog.Add ("All is tickety-boo!”");
		TimDialogHappy.Add ("This forest is beautiful."); // happy
		TimDialogHappy.Add ("Where are the mushrooms?"); // happy
		TimDialogScared.Add ("I wonder if there are wolves in this forest."); // scared
		TimDialogScared.Add ("I want to go home."); // scared
		TimDialogScared.Add ("I have a feeling something’s watching me."); // scared
		TimDialogScared.Add ("Aaah! Oh, it was just a butterfly."); // scared
		TimDialogAngry.Add ("What am I doing here?"); // angry
		TimDialogAngry.Add ("That flower looks stupid."); // angry
		TimDialogAngry.Add ("I really want to punch something."); // angry




//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");
//		otherDialog.Add ("");


	}

}
