using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MenuManager {

	public GameObject InGameMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (InGameMenu.activeInHierarchy)
				CloseMenu ();
			else
				OpenMenu ();
		}
	}
	public void OpenMenu() {
		Time.timeScale = 0f;
		InGameMenu.SetActive (true);
	}

	public void CloseMenu() {
		Time.timeScale = 1f;
		InGameMenu.SetActive (false);
	}
}
