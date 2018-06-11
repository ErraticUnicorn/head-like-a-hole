using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer audioMixer;
	public Slider volumeSlider;

	private AudioManager audioManager;

	void Start() {
		audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager>();
		volumeSlider.value = audioManager.masterVolume;
	}

	public void setVolume(float volume) {
		audioMixer.SetFloat ("volume", volume);
		audioManager.SetMasterVolume (volume);
	}
}
