using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeScene(string scene) {
		Time.timeScale = 1f;
		SceneManager.LoadScene (scene);
	}

	public void ExitGame() {
		Debug.Log ("Fechando o jogo!");
		Application.Quit ();
	}
}
