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

    public GameObject Player;
	private AudioSource Audio;

	// Use this for initialization
	void Start () {
		Audio = Player.transform.GetChild (0).GetComponent<AudioSource> ();
	}
	
	public void SetMusicVolume(float volume) {
		Audio.volume = volume;
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

    public void Mute(bool isMuted)
    {
        print("ismuted " + isMuted);
        Player.GetComponent<AudioListener>().enabled = isMuted;
        print(Player.GetComponent<AudioListener>().enabled);
    }
}
