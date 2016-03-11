using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public float speed = 0;
	public bool running = true;


	// Update is called once per frame
	void Update () {

		if (running == true) {
			MeshRenderer mr = GetComponent<MeshRenderer> ();
			Material mat = mr.material;

			Vector2 offset = mat.mainTextureOffset;

			offset.x += Time.deltaTime * speed / 10;

			mat.mainTextureOffset = offset;

		} 
			
	}
	public void stopScroll(){
		running = false;
	}

	public void startScroll(){
		running = true;
	}
}
