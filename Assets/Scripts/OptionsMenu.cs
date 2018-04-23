using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {

	public GameObject InGameMenu;
	public GameObject OptionMenu;
	public AudioMixer audioMixer;

	// Use this for initialization
	void Start () {

	}
	
	public void SetMusicVolume(float volume) {
		audioMixer.SetFloat ("MusicVolume", volume);
	}

	public void SetSFXVolume(float volume) {

	}

	public void SetQuality (int qualityIndex) {
		QualitySettings.SetQualityLevel (qualityIndex);
	}

	public void SetFullscreen (bool isFullscreen) {
		Screen.fullScreen = isFullscreen;
	}

	public void CloseOptions() {
		OptionMenu.SetActive (false);
		InGameMenu.SetActive (true);
	}
}
