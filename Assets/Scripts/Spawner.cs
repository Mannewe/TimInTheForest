using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemiesObjects;
	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForSpawn(3f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitForSpawn(float waitTime){
		yield return new WaitForSeconds (waitTime);
		GameObject shrubbery = (GameObject)Instantiate (enemiesObjects [0]);
	}
}
