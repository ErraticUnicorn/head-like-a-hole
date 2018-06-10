using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject resumeButton;
	private InputController inputController;
	private string pauseButton;
	private bool controllersConnected = false;
	private GameObject eventSystem;

	void Start () {
		eventSystem = GameObject.Find ("EventSystem");
		if (Input.GetJoystickNames ().Length > 0) {
			controllersConnected = true;
		} 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown ("joystick button 7")) {
			if (gameIsPaused) {
				Resume();
			} else {
				Pause();
			}
		}
	}

	public void Resume() {
		gameIsPaused = false;
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
	}

	void Pause() {
		gameIsPaused = true;
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		if (controllersConnected) {
			eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(resumeButton);
		}
	}

	public void LoadMenu() {
		Debug.Log ("Loading Menu...");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
