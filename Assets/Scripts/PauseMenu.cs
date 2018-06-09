using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	private InputController inputController;
	private string pauseButton;

	void Start () {
		//inputController = GameObject.FindWithTag ("GameController").GetComponent<InputController>();
		//inputController.GetBodyHorizontalInputString (playerNum);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
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
	}

	public void LoadMenu() {
		Debug.Log ("Loading Menu...");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
