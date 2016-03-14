using UnityEngine;
using System.Collections;

public class MoodChange : MonoBehaviour {

	GameObject tim;
	Tim timScript;

	public Sprite sprite0;
	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Sprite sprite6;
	public Sprite sprite7;
	public Sprite sprite8;
	public Sprite sprite9;
	public Sprite sprite10;

	private SpriteRenderer spriteRenderer; 

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) {// if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
		}

		tim = GameObject.FindWithTag ("tim");
		timScript = tim.GetComponent<Tim> ();
	}

	void Update ()
	{
		//if (Input.GetKeyDown (KeyCode.Space)) // If the space bar is pushed down
		//{
			ChangeTheDamnSprite (); // call method to change sprite
		//}
	}

	void ChangeTheDamnSprite ()
	{
		if (timScript.mood == 0) {
			spriteRenderer.sprite = sprite0;
		}

		if (timScript.mood == 1) {
			spriteRenderer.sprite = sprite1;
		}

		if (timScript.mood == 2) {
			spriteRenderer.sprite = sprite2;
		}

		if (timScript.mood == 3) {
			spriteRenderer.sprite = sprite3;
		}

		if (timScript.mood == 4) {
			spriteRenderer.sprite = sprite4;
		}

		if (timScript.mood == 5) {
			spriteRenderer.sprite = sprite5;
		}

		if (timScript.mood == 6) {
			spriteRenderer.sprite = sprite6;
		}

		if (timScript.mood == 7) {
			spriteRenderer.sprite = sprite7;
		}

		if (timScript.mood == 8) {
			spriteRenderer.sprite = sprite8;
		}

		if (timScript.mood == 9) {
			spriteRenderer.sprite = sprite9;
		}

		if (timScript.mood == 10) {
			spriteRenderer.sprite = sprite10;
		}
			
	}
}
