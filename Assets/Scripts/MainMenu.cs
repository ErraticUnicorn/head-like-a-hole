using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject playButton;
	public GameObject backButton;
	public GameObject optionsMenu;
	public GameObject startMenu;

	private GameObject eventSystem;
	private bool controllersConnected = false;

	void Awake() {
		eventSystem = GameObject.Find ("EventSystem");
		if (Input.GetJoystickNames ().Length > 0) {
			controllersConnected = true;
			eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(playButton);
		} 
	}

	public void PlayGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void Options() {
		startMenu.SetActive (false);
		optionsMenu.SetActive (true);
		if (controllersConnected) {
			eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(backButton);
		}
	}

	public void Back() {
		optionsMenu.SetActive (false);
		startMenu.SetActive (true);
		if (controllersConnected) {
			eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(playButton);
		}
	}
}
