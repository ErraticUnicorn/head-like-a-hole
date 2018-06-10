using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	private static AudioManager instance = null;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start () {
		//Good thing for a Game Manager?
		Scene scene = SceneManager.GetActiveScene ();
		if (scene.name == "Main_Menu") {
			Play ("Title Theme");
		} else {
			Play ("Main Theme");
		}
	}

	public void Play(string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("No sound of that name found!");
			return;
		}
		if (!s.source.isPlaying) {
			s.source.Play ();
		}
	}
}
