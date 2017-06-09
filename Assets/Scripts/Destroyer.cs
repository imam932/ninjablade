using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		// if object triggered
		if(other.tag == "Player"){
			Application.LoadLevel(4);
			return;
		}

		if(other.gameObject.transform.parent){
			Destroy(other.gameObject.transform.parent.gameObject);
		}else{
			Destroy(other.gameObject);
		}
	}
}
