using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvoidEarlySoundRestart : MonoBehaviour{
	public AudioSource audioSource;
	public Text buttonText;
	void Update(){
		string statusMessage = " ";

		if(audioSource.isPlaying )
			statusMessage = "(sound playing)";

		buttonText.text = statusMessage;
	}

	public void PlaySoundIfNotPlaying(){
		if( !audioSource.isPlaying )
			audioSource.Play();
	}
}