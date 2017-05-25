using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuQuit : MonoBehaviour {
    public Button quit;

	// Use this for initialization
	void Start () {
        quit.onClick.AddListener(() => {
            Application.Quit();
        });
    }
	
}
