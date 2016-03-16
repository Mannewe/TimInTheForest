using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public float speed = 0;
	public bool running = true;

	GameObject tim;
	Tim timScript;

	void Start() {
		tim = GameObject.FindWithTag ("tim");
		timScript = tim.GetComponent<Tim> ();
	}

	// Update is called once per frame
	void Update () {

		if (running == true) {
			MeshRenderer mr = GetComponent<MeshRenderer> ();
			Material mat = mr.material;

			Vector2 offset = mat.mainTextureOffset;

			offset.x += Time.deltaTime * speed / 10;

			mat.mainTextureOffset = offset;

		} 
			
		stopAtEnd ();
	}
	public void stopScroll(){
		running = false;
	}

	public void startScroll(){
		running = true;
	}

	public void stopAtEnd(){
		if (timScript.gameState == "Peace1") {
			speed = 0;
		}

		if (timScript.gameState == "Peace2") {
			speed = 0;
		}

		if (timScript.gameState == "Lost1") {
			speed = 0;
		}

		if (timScript.gameState == "Lost2") {
			speed = 0;
		}

		if (timScript.gameState == "Death1") {
			speed = 0;
		}

		if (timScript.gameState == "Death2") {
			speed = 0;
		}

		if (timScript.gameState == "Death3") {
			speed = 0;
		}

		if (timScript.gameState == "Death4") {
			speed = 0;
		}

		if (timScript.gameState == "Slave1") {
			speed = 0;
		}

		if (timScript.gameState == "Slave2") {
			speed = 0;
		}

		if (timScript.gameState == "Slave3") {
			speed = 0;
		}

		if (timScript.gameState == "OutOfTheForest1") {
			speed = 0;
		}

		if (timScript.gameState == "OutOfTheForest2") {
			speed = 0;
		}

		if (timScript.gameState == "King1") {
			speed = 0;
		}
	}
}
