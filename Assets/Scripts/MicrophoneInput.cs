using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
	public float sensitivity = 100;
	public float loudness = 0;
	GameObject tim;
	Tim timscript;

	bool talkDelayer = true;

	void Start() {
		GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100);
		GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
		GetComponent<AudioSource>().mute = false; // Mute the sound, we don't want the player to hear it
		while (!(Microphone.GetPosition(null) > 0)){} // Wait until the recording has started
		GetComponent<AudioSource>().Play(); // Play the audio source!

		tim = GameObject.FindWithTag ("tim");
		timscript = tim.GetComponent<Tim> ();
	}
	
	void Update(){
		loudness = GetAveragedVolume() * sensitivity;
		//print (loudness);

		if (talkDelayer == true) {
			if (loudness > 3 && loudness <= 5) {
				StartCoroutine (WhisperDelay(0.3f));
//				timscript.Whisper (true);
				talkDelayer = false;
				StartCoroutine (talkDelay(5f));
			}

			if (loudness > 5) {
				StartCoroutine (YellDelay(0.3f));
				//timscript.Yell (true);
				talkDelayer = false;
				StartCoroutine (talkDelay(5f));
			}
		}

	}
	
	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		GetComponent<AudioSource>().GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
	}

	IEnumerator talkDelay(float waitTime){
	yield return new WaitForSeconds (waitTime);
		talkDelayer = true;
	}

	IEnumerator WhisperDelay(float waitTime){
		yield return new WaitForSeconds (waitTime);
		timscript.Whisper (true);
		//talkDelayer = false;
		//StartCoroutine (talkDelay(1f));
	}

	IEnumerator YellDelay(float waitTime){
		yield return new WaitForSeconds (waitTime);
		timscript.Yell (true);
		//talkDelayer = false;
		//StartCoroutine (talkDelay(1f));
	}
}