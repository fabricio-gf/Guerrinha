using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MenuManager {

	public GameObject InGameMenu;
	public GameObject OptionMenu;

	public FirstPersonController player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !OptionMenu.activeInHierarchy) {
			if (InGameMenu.activeInHierarchy)
				CloseMenu ();
			else
				OpenMenu ();
		}
	}
	public void OpenMenu() {
		player.enabled = false;
		Time.timeScale = 0f;
		InGameMenu.SetActive (true);
	}

	public void CloseMenu() {
		player.enabled = true;
        Time.timeScale = 1f;
		InGameMenu.SetActive (false);
	}

	public void OpenOptions() {
        OptionMenu.SetActive (true);
		InGameMenu.SetActive (false);
	}
}
