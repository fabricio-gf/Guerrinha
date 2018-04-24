using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject Music;

	public void ChangeScene(string scene) {
		Time.timeScale = 1f;
        Music = GameObject.FindGameObjectWithTag("Music");
        if(scene == "Menu")
        {
            Destroy(Music);
        }
		SceneManager.LoadScene (scene);
	}

	public void ExitGame() {
		Debug.Log ("Fechando o jogo!");
		Application.Quit ();
	}
}
