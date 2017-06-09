using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	void Start () {
		
	}
	
	void OnGUI () {
		// retry button
		GUI.contentColor = Color.green;
		if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2 +100,100,40),"Retry?")){
			Application.LoadLevel(3);
		}

	//Home 
		GUI.contentColor = Color.green;
		if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2 +150,100,40),"Back to Home")){
			Application.LoadLevel(0);
		}

		// Quit button
		GUI.contentColor = Color.red;
		if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2 +200,100,40),"Quit")){
			Application.Quit();
		}
	}
}
