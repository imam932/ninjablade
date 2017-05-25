using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour {

	public void MENU_ACTION_NEXTLEVEL(string scaneName){
        Application.LoadLevel(scaneName);
    }
}
