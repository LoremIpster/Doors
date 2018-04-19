using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	private bool isMenu;

	void Start(){
		if (Application.loadedLevel == 0) {
			Cursor.visible = true;
			isMenu = true;
			print ("yas");
		}
	}

	void Update(){
		if (Input.GetKey ("escape")) {
			if (isMenu) {
				Application.Quit ();
			} else {
				SceneManager.LoadScene("Menu", LoadSceneMode.Single);
			}
		}
	}

	public void LoadSceneGym(){
		SceneManager.LoadScene("Gym", LoadSceneMode.Single);
	}
}
